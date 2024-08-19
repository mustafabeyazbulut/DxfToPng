using atelLibDXF;
using atelLibDXF.Entities;
using atelLibDXF.Tables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public class DXFDAL
{
    #region DXF Çizim Değişkenleri
    //private int iVirtualKeysFormX;
    // private int iVirtualKeysFormY;
    // Control Keys positions control
    //private int iControlKeysFormX;
    //private int iControlKeysFormY;
    // User info & First Control
    //private string sPersonalNmr = "";
    //private string sPersonalName = "";
    //private bool bUserAdmin = false;
    //private string sLastPastalCode = "";
    //private string sPartsName = "";
    // First Control (2018.10.05)
    // User must be asked about pastal and parts in it controlled
    //private string sPastalCodeControlled = "";
    //private string sPartsNameControlled = "";
    //private bool bA_PartAlreadyCheckedAsToBeControlled = false;
    private static double dMinDirectionLineLength = 20.0D;
    private static int iPastalIndex = 0;
    private static int iNumOfPastalFilesInPastalDirectory = 0;
    private static TemplateClass Template = new TemplateClass();
    private static string[] templatesInPastalDirectory;
    //string sTemplatesDirectoryNamePath;
    //float fAxisOriginX = 20.0F;
    //float fAxisOriginY = 20.0F;
    //float fTotalRotationAngle = 0;
    #endregion

    #region DXF fonksiyonları

    private static float PolygonArea(List<PointF> points)
    {
        return Math.Abs(SignedPolygonArea(points));
    }
    private static float SignedPolygonArea(List<PointF> points)
    {
        // İlk noktayı son noktaya ekle
        int iNumPoints = points.Count;
        PointF[] pts = new PointF[iNumPoints + 1];
        points.CopyTo(pts, 0);
        pts[iNumPoints] = points[0];
        // Alanı bul
        float fArea = 0;
        for (int i = 0; i < iNumPoints; i++)
        {
            fArea +=
                (pts[i + 1].X - pts[i].X) *
                (pts[i + 1].Y + pts[i].Y) / 2;
        }

        return fArea;
    }
    private static void GetDXF_Parts()
    {
        //TextWriter tw_dxf_parts = new StreamWriter("d:\\Temp\\parts_list.txt");
        DxfDocument DXFToProcess = new DxfDocument();
        Polyline tempPolyLine = new Polyline();
        List<LineSegmentClass> listLineSegmentForDrawingErrorsControl = new List<LineSegmentClass>();
        List<LineSegmentClass> listLineSegment = new List<LineSegmentClass>();
        PointF tempPointF = new PointF();
        List<PointF> listPolylineToPointFs = new List<PointF>();
        Template.Polylines.Clear();
        Template.Lines.Clear();
        Template.Circles.Clear();
        //Template.I_Cits.Clear();
        //Template.V_Cits.Clear();
        Template.DirectionLine = null;
        // To find direction line
        double dWidthOfOuterPart = 0.0;
        int iWidthOfOuterPart = 0;
        double dHeightOfOuterPart = 0.0;
        int iHeightOfOuterPart = 0;
        double dPossibleDirectionLineYOrigin = 0.0;
        double dPossibleDirectionLineYDelta = 0.0;
        double dYDeltaKoeffizient = 0.01;
        int iPossibleDirectionLineY = 0;
        //bool bDirectionLineInPartFound = false;
        // Load DXF-File
        DXFToProcess.Load(Template.FileName);
        // Get blocks number in DXF-File
        int iBlocksCount = DXFToProcess.Blocks.Count;
        // Block-Type DXF-File
        // What we normally need (Prefer this format)
        if (iBlocksCount == 1)
        {
            int iNumOfEntities = DXFToProcess.Blocks[0].Entities.Count;
            for (int iEntityCounter = 0; iEntityCounter < iNumOfEntities; iEntityCounter++)
            {
                EntityType t = DXFToProcess.Blocks[0].Entities[iEntityCounter].Type;
                Layer l = DXFToProcess.Blocks[0].Entities[iEntityCounter].Layer;

                // If EntityType = Polyline & Layer = {CUT} then MainPolynom
                if (t == EntityType.Polyline && l.Name == "CUT")
                {
                    Template.Polylines.Add((Polyline)DXFToProcess.Blocks[0].Entities[iEntityCounter]);
                }
                // If EntityType = Polyline & Layer = {U} then Drill
                if (t == EntityType.Polyline && l.Name == "U")
                {
                    Template.Circles.Add((Polyline)DXFToProcess.Blocks[0].Entities[iEntityCounter]);
                }
                // If EntityType = Polyline & Layer = {I} then inner shape
                if (t == EntityType.Polyline && l.Name == "I")
                {
                    Template.Circles.Add((Polyline)DXFToProcess.Blocks[0].Entities[iEntityCounter]);
                }
                // If EntityType = Line & Layer = {I} then Cut/Knife
                if (t == EntityType.Line && l.Name == "I")
                {
                    Template.Lines.Add((Line)DXFToProcess.Blocks[0].Entities[iEntityCounter]);
                }
                // If EntityType = Line & Layer = {U} then Cut/Knife
                if (t == EntityType.Line && l.Name == "U")
                {
                    Template.Lines.Add((Line)DXFToProcess.Blocks[0].Entities[iEntityCounter]);
                }
            }
        }
        else // Polynom-Type DXF-File
        {
            int iNumOfPolylinesInDXF = DXFToProcess.Polylines.Count;
            // To find outer polygon
            float fLargestArea = 0;
            int iPolylineIndexWithLargestArea = 0;
            int iNumOfVertexesOnPolylineWithLargestArea = 0;
            int iIndexOfDoubleOuterPolygon = 0;
            int iNumOfLines = 0;
            #region Detect folded polygons and correct these
            for (int i = 0; i < iNumOfPolylinesInDXF; i++)
            {
                tempPolyLine = (Polyline)DXFToProcess.Polylines[i];
                //Template.Polylines.Add(tempPolyLine);
                if (tempPolyLine.Vertexes.Count > 3)
                {
                    // Control if folded polygon
                    if (tempPolyLine.Vertexes[1].Location.X == tempPolyLine.Vertexes[tempPolyLine.Vertexes.Count - 2].Location.X)
                    {
                        if (tempPolyLine.Vertexes[1].Location.Y == tempPolyLine.Vertexes[tempPolyLine.Vertexes.Count - 2].Location.Y)
                        {
                            int iStartIndex = (tempPolyLine.Vertexes.Count + 1) / 2;
                            int iCount = tempPolyLine.Vertexes.Count - iStartIndex;
                            tempPolyLine.Vertexes.RemoveRange(iStartIndex, iCount);
                        }
                    }
                }
            }
            #endregion
            for (int i = 0; i < iNumOfPolylinesInDXF; i++)
            {
                float fTempArea = 0;
                tempPolyLine = (Polyline)DXFToProcess.Polylines[i];

                if (tempPolyLine.Vertexes.Count == 2)
                {
                    iNumOfLines++;
                }
                // If polyline is not a line then find area
                if (tempPolyLine.Vertexes.Count > 2)
                {
                    for (int n = 0; n < tempPolyLine.Vertexes.Count - 1; n++)
                    {
                        tempPointF.X = (float)tempPolyLine.Vertexes[n].Location.X;
                        tempPointF.Y = (float)tempPolyLine.Vertexes[n].Location.Y;
                        listPolylineToPointFs.Add(tempPointF);
                    }

                    fTempArea = PolygonArea(listPolylineToPointFs);
                    listPolylineToPointFs.Clear();
                    // Find polygon-index with largest area
                    // That must be outer polygon
                    if (fTempArea > fLargestArea)
                    {
                        iPolylineIndexWithLargestArea = i;
                        fLargestArea = fTempArea;
                        iNumOfVertexesOnPolylineWithLargestArea = tempPolyLine.Vertexes.Count;
                    }
                    if (fTempArea == fLargestArea)
                    {
                        iIndexOfDoubleOuterPolygon = i;
                    }
                }
            }
            // Find direction line length
            tempPolyLine = (Polyline)DXFToProcess.Polylines[iPolylineIndexWithLargestArea];
            // Find width of outer part
            double dMinX = 0.0;
            double dMaxX = 0.0;
            double dMinY = 0.0;
            double dMaxY = 0.0;
            for (int iVertexCounter = 0; iVertexCounter < tempPolyLine.Vertexes.Count; iVertexCounter++)
            {
                if (tempPolyLine.Vertexes[iVertexCounter].Location.X < dMinX)
                {
                    dMinX = tempPolyLine.Vertexes[iVertexCounter].Location.X;
                }
                if (tempPolyLine.Vertexes[iVertexCounter].Location.X > dMaxX)
                {
                    dMaxX = tempPolyLine.Vertexes[iVertexCounter].Location.X;
                }
                if (tempPolyLine.Vertexes[iVertexCounter].Location.Y < dMinY)
                {
                    dMinY = tempPolyLine.Vertexes[iVertexCounter].Location.Y;
                }
                if (tempPolyLine.Vertexes[iVertexCounter].Location.Y > dMaxY)
                {
                    dMaxY = tempPolyLine.Vertexes[iVertexCounter].Location.Y;
                }
                dWidthOfOuterPart = dMaxX - dMinX;
                iWidthOfOuterPart = (int)dWidthOfOuterPart;
                dHeightOfOuterPart = dMaxY - dMinY;
                iHeightOfOuterPart = (int)dHeightOfOuterPart;
                dPossibleDirectionLineYOrigin = dHeightOfOuterPart / 2 + dMinY;
                iPossibleDirectionLineY = (int)dPossibleDirectionLineYOrigin;
                dPossibleDirectionLineYDelta = dHeightOfOuterPart * dYDeltaKoeffizient;
                dMinDirectionLineLength = (dWidthOfOuterPart / 2) - 0.5;
            }

            for (int iPolyCounter = 0; iPolyCounter < iNumOfPolylinesInDXF; iPolyCounter++)
            {
                // Get actual polyline and copy to tempPolyLine
                tempPolyLine = (Polyline)DXFToProcess.Polylines[iPolyCounter];
                #region Add outer polygon
                // Add outer polyline
                if ((tempPolyLine.Vertexes.Count > 2) && (iPolyCounter == iPolylineIndexWithLargestArea))
                {
                    // Outer polygon
                    Template.Polylines.Add(tempPolyLine);
                }
                #endregion
                #region Add circles/inner holes
                // Add circles/inner holes
                // Added on 2018.11.12 for irregular inner 
                // and double outer line
                if ((tempPolyLine.Vertexes.Count > 3) && (iPolyCounter != iPolylineIndexWithLargestArea))
                {
                    if ((iPolyCounter != iIndexOfDoubleOuterPolygon) && (iNumOfVertexesOnPolylineWithLargestArea != tempPolyLine.Vertexes.Count))
                    {
                        Template.Circles.Add(tempPolyLine);
                    }
                }
                #endregion
                // Detect direction line
                if (iNumOfLines > 1)
                {
                    //// Add lines
                    if ((tempPolyLine.Vertexes.Count == 2) || (tempPolyLine.Vertexes.Count == 3))
                    {
                        int iVertexCount = tempPolyLine.Vertexes.Count;
                        Polyline tempNextPolyLine = new Polyline();

                        if (tempPolyLine.Vertexes[0].Location.Y != tempPolyLine.Vertexes[iVertexCount - 1].Location.Y)
                        {
                            Vector3 startPoint = new Vector3(tempPolyLine.Vertexes[0].Location.X, tempPolyLine.Vertexes[0].Location.Y, 0);
                            Vector3 endPoint = new Vector3(tempPolyLine.Vertexes[iVertexCount - 1].Location.X, tempPolyLine.Vertexes[iVertexCount - 1].Location.Y, 0);
                            Line tempLine = new Line(startPoint, endPoint);

                            Template.Lines.Add(tempLine);
                        }
                        else if ((tempPolyLine.Vertexes[0].Location.Y < (dPossibleDirectionLineYOrigin - dPossibleDirectionLineYDelta)) || (tempPolyLine.Vertexes[0].Location.Y > (dPossibleDirectionLineYOrigin + dPossibleDirectionLineYDelta)))
                        {
                            Vector3 startPoint = new Vector3(tempPolyLine.Vertexes[0].Location.X, tempPolyLine.Vertexes[0].Location.Y, 0);
                            Vector3 endPoint = new Vector3(tempPolyLine.Vertexes[iVertexCount - 1].Location.X, tempPolyLine.Vertexes[iVertexCount - 1].Location.Y, 0);
                            Line tempLine = new Line(startPoint, endPoint);
                            Template.Lines.Add(tempLine);
                        }
                    }
                }
            }
        }
    }
    public static bool DrawThumbnails(string sDXFDirectory)
    {
        try
        {
            int iImageScaler = 2;

            string sThumbnailsDirectory = sDXFDirectory + "\\Thumbnails_cadviewer";

            string[] listDXFFilesWithPathInDirectory = Directory.GetFiles(sDXFDirectory, "*.dxf", SearchOption.TopDirectoryOnly)
                                                        .OrderBy(filename => filename)
                                                        .ToArray();

            string[] listDXFFileNamesInDirectory = Directory.GetFiles(sDXFDirectory, "*.dxf", SearchOption.TopDirectoryOnly)
                        .Select(Path.GetFileName)
                        .OrderBy(filename => filename)
                        .ToArray();

            if (listDXFFilesWithPathInDirectory.Length == 0)
            {
                return false;
            }


            Directory.CreateDirectory(sThumbnailsDirectory);

            // Delete previous thumbnails
            DirectoryInfo di = new DirectoryInfo(sThumbnailsDirectory);

            FileInfo[] files = di.GetFiles("*.png")
                                 .Where(p => p.Extension == ".png").ToArray();
            foreach (FileInfo file in files)
                try
                {
                    file.Attributes = FileAttributes.Normal;
                    File.Delete(file.FullName);
                }
                catch
                {
                }


            //foreach (string tempDXF in listDXFFilesInDirectory)
            for (int iFileCount = 0; iFileCount < listDXFFilesWithPathInDirectory.Length; iFileCount++)
            {
                Template.FileName = listDXFFilesWithPathInDirectory[iFileCount];
                GetDXF_Parts();

                string sFileToSave = Path.GetFileNameWithoutExtension(listDXFFilesWithPathInDirectory[iFileCount]);

                Bitmap bmpDXFImage_to_thumbnail;

                Text textDXF = new Text();

                List<PointF> listPointFs = new List<PointF>();
                PointF tempPointF = new PointF();
                PointF pfStartLine = new PointF();
                PointF pfEndLine = new PointF();

                PointF[] polyPoints = { };

                // Brushes and pens
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                Pen blackPen_3 = new Pen(Color.Black, 3);

                Template.MinX = 2000.0F;
                Template.MinY = 2000.0F;
                Template.MaxX = 0.0F;
                Template.MaxY = 0.0F;

                float fExtraSpacing_Y = 0.0F;

                int iSpaceInPixelsForTemplateName = 100;

                int polyCounter = Template.Polylines.Count;

                // Find Min, Max
                for (int i = 0; i < Template.Polylines[polyCounter - 1].Vertexes.Count; i++)
                {
                    tempPointF.X = (float)Template.Polylines[polyCounter - 1].Vertexes[i].Location.X;
                    tempPointF.Y = (float)Template.Polylines[polyCounter - 1].Vertexes[i].Location.Y;

                    if (tempPointF.X < Template.MinX)
                    {
                        Template.MinX = tempPointF.X;
                    }

                    if (tempPointF.X > Template.MaxX)
                    {
                        Template.MaxX = tempPointF.X;
                    }

                    if (tempPointF.Y < Template.MinY)
                    {
                        Template.MinY = tempPointF.Y;
                    }

                    if (tempPointF.Y > Template.MaxY)
                    {
                        Template.MaxY = tempPointF.Y;
                    }
                }

                Template.Width = Template.MaxX - Template.MinX;
                Template.Height = Template.MaxY - Template.MinY;
                float fConvertY = (Template.Height) + (2 * Template.Y_BordersSpacing);

                // Calculate image width and height
                int iImageWidth = (int)((Template.Width + (2 * Template.X_BordersSpacing)) * Template.ScaleCoefficient);
                int iImageHeight = (int)((Template.Height + (2 * Template.Y_BordersSpacing)) * Template.ScaleCoefficient);

                if (iImageWidth < iImageHeight) iImageWidth = iImageHeight;

                float fPenWidth;

                int iImageSizeX;
                float fPenWidthFactor = 0.5F;
                if (iImageWidth > iImageHeight)
                {
                    fPenWidth = (float)((iImageWidth / 100) * fPenWidthFactor);
                    iImageSizeX = iImageWidth;

                    fExtraSpacing_Y = ((iImageWidth - iImageHeight) / 2) / Template.ScaleCoefficient;
                }
                else
                {
                    fPenWidth = (float)((iImageHeight / 100) * fPenWidthFactor);
                    iImageSizeX = iImageHeight;
                }

                int iAlpha = 255;
                Pen blackPen_fPenWidth = new Pen(Color.FromArgb(iAlpha, 0, 0, 0), fPenWidth);
                Pen redPen_fPenWidth = new Pen(Color.FromArgb(iAlpha, 255, 0, 0), fPenWidth); // For Airbag

                // Thumbnail size

                int iImageSizeY = iImageSizeX + iSpaceInPixelsForTemplateName;
                bmpDXFImage_to_thumbnail = new Bitmap(iImageSizeX / iImageScaler, iImageSizeY / iImageScaler);

                System.Drawing.Graphics graphicsImageToThumbnail = Graphics.FromImage(bmpDXFImage_to_thumbnail);

                // White background
                //graphicsImageToThumbnail.FillRectangle(whiteBrush, 0, 0, iImageWidth, iImageHeight);
                graphicsImageToThumbnail.FillRectangle(whiteBrush, 0, 0, iImageSizeX / iImageScaler, iImageSizeX / iImageScaler);

                // IMAGE-TO-SHOW
                // Draw Polylines for Image-to-Show
                for (int i = 0; i < polyCounter; i++)
                {
                    for (int iVertexCounter = 0; iVertexCounter < Template.Polylines[i].Vertexes.Count; iVertexCounter++)
                    {
                        tempPointF.X = Template.ScaleCoefficient * ((float)Template.Polylines[i].Vertexes[iVertexCounter].Location.X - Template.MinX + Template.X_BordersSpacing);
                        tempPointF.Y = Template.ScaleCoefficient * (fConvertY - ((float)Template.Polylines[i].Vertexes[iVertexCounter].Location.Y - Template.MinY + Template.Y_BordersSpacing - fExtraSpacing_Y));

                        tempPointF.X = tempPointF.X / iImageScaler;
                        tempPointF.Y = tempPointF.Y / iImageScaler;

                        listPointFs.Add(tempPointF);
                    }
                    polyPoints = listPointFs.ToArray();

                    graphicsImageToThumbnail.DrawPolygon(blackPen_fPenWidth, polyPoints);
                    listPointFs.Clear();
                }

                for (int i = 0; i < Template.Circles.Count; i++)
                {
                    for (int iVertexCounter = 0; iVertexCounter < Template.Circles[i].Vertexes.Count; iVertexCounter++)
                    {
                        tempPointF.X = Template.ScaleCoefficient * ((float)Template.Circles[i].Vertexes[iVertexCounter].Location.X - Template.MinX + Template.X_BordersSpacing);
                        tempPointF.Y = Template.ScaleCoefficient * (fConvertY - ((float)Template.Circles[i].Vertexes[iVertexCounter].Location.Y - Template.MinY + Template.Y_BordersSpacing - fExtraSpacing_Y));

                        tempPointF.X = tempPointF.X / iImageScaler;
                        tempPointF.Y = tempPointF.Y / iImageScaler;

                        listPointFs.Add(tempPointF);
                    }
                    polyPoints = listPointFs.ToArray();
                    graphicsImageToThumbnail.DrawPolygon(blackPen_fPenWidth, polyPoints);

                    listPointFs.Clear();
                }

                // Draw Lines for Image-to-Show
                for (int i = 0; i < Template.Lines.Count; i++)
                {
                    pfStartLine.X = Template.ScaleCoefficient * ((float)Template.Lines[i].StartPoint.X - Template.MinX + Template.X_BordersSpacing);
                    pfStartLine.Y = Template.ScaleCoefficient * (fConvertY - ((float)Template.Lines[i].StartPoint.Y - Template.MinY + Template.Y_BordersSpacing - fExtraSpacing_Y));
                    pfEndLine.X = Template.ScaleCoefficient * ((float)Template.Lines[i].EndPoint.X - Template.MinX + Template.X_BordersSpacing);
                    pfEndLine.Y = Template.ScaleCoefficient * (fConvertY - ((float)Template.Lines[i].EndPoint.Y - Template.MinY + Template.Y_BordersSpacing - fExtraSpacing_Y));

                    pfStartLine.X = pfStartLine.X / iImageScaler;
                    pfStartLine.Y = pfStartLine.Y / iImageScaler;
                    pfEndLine.X = pfEndLine.X / iImageScaler;
                    pfEndLine.Y = pfEndLine.Y / iImageScaler;

                    graphicsImageToThumbnail.DrawLine(blackPen_fPenWidth, pfStartLine, pfEndLine);
                }

                if (!File.Exists(sThumbnailsDirectory + "\\" + sFileToSave + ".png"))
                {
                    bmpDXFImage_to_thumbnail.Save(sThumbnailsDirectory + "\\" + sFileToSave + ".png", System.Drawing.Imaging.ImageFormat.Png);
                }
            }

            return true;
        }
        catch (Exception)
        {
            return false;

        }
    }
    public static List<ParcaPhotoDTO> LoadThumbnails(string sTemplatesDirectoryNamePath, string _parcaIsmı, string _Kmalzeme, int _miktar)
    {
        List<ParcaPhotoDTO> parcaPhotoList = new List<ParcaPhotoDTO>();
        try
        {
            templatesInPastalDirectory = Directory.GetFiles(sTemplatesDirectoryNamePath, "*.dxf")
                                              .OrderBy(filename => filename)
                                              .ToArray();


            if (templatesInPastalDirectory.Length == 0)
            {

                DialogResult dr = MessageBox.Show("Seçilen Pastal klasörü içerisinde DXF dosyası bulunmamaktadır.",
        "PASTAL BİLGİSİ", MessageBoxButtons.OK);

                return parcaPhotoList;
            }

            string sThumbnailsDirectoryPath = sTemplatesDirectoryNamePath + "\\Thumbnails_cadviewer";



            //Initialize a new List of type Image as ImagesInFolder
            List<Image> ThumbnailsInFolder = new List<Image>();
            List<string> ParcaIsmi = new List<string>();
            //Initialize a new string of name PNGImages for every string in the string array returned from the given folder as files
            foreach (string PNGImages in Directory.GetFiles(sThumbnailsDirectoryPath, "*.png").OrderBy(filename => filename).ToArray())
            {
                if (PNGImages.Remove(0, PNGImages.LastIndexOf("\\") + 1).Replace(".png", "") == _parcaIsmı)
                {
                    Image image = Image.FromFile(PNGImages);
                    string sPatternName = Path.GetFileNameWithoutExtension(PNGImages);
                    //string sSubPatternName = sPatternName.Substring(3);

                    float fFontSize = (float)(image.Width / 12);

                    int iLengthPatternName = sPatternName.Length;

                    if (iLengthPatternName > 16)
                    {
                        fFontSize = fFontSize - 24;
                    }
                    // Create graphics from image
                    Graphics graphics = Graphics.FromImage(image);
                    // Create font
                    //Font font = new Font("Microsoft Sans Serif", fFontSize, FontStyle.Bold);
                    if (fFontSize <= 0)
                    {
                        fFontSize = 15;
                    }
                    Font font = new Font("Microsoft Sans Serif", fFontSize, FontStyle.Regular);
                    // Draw text
                    //graphics.DrawString(sPatternName, font, Brushes.DarkBlue, point);
                    //graphics.DrawString(sPatternName, font, Brushes.DarkBlue, new PointF(0, 100.0F));

                    graphics.DrawString(sPatternName, font, Brushes.DarkBlue, new PointF(0, image.Height - (fFontSize * 1.3F)));

                    //graphics.DrawString(sPatternName, font, Brushes.DarkBlue, new PointF(0, image.Height - (fFontSize * 1.3F)));
                    ThumbnailsInFolder.Add(image); //Add the Image gathered to the List collection
                    ParcaIsmi.Add(PNGImages.Remove(0, PNGImages.LastIndexOf("\\") + 1).Replace(".png", ""));
                }
            }

            int x = 0;
            int y = 0;
            for (int i = 0; i < ThumbnailsInFolder.Count; i++)
            {
                if (ParcaIsmi[i] == _parcaIsmı)
                {
                    PictureBox I = new PictureBox(); //Initialize a new PictureBox of name I
                    I.Tag = ParcaIsmi[i] + "~" + _Kmalzeme;
                    I.Location = new System.Drawing.Point(x, y); //Set the PictureBox location to x,y
                    x += 100; //Sort horizontally; Increment x by 100
                              //y += 50; //Sort vertically; Increment y by 50
                    I.Image = ThumbnailsInFolder[i]; //Set the Image property of I to i in ImagesInFolder as index
                                                     //I.Size = new System.Drawing.Size(110, 110); //Set the PictureBox Size property to 110,100
                    I.Size = new System.Drawing.Size(110, 100); //Set the PictureBox Size property to 110,100
                                                                //I.Size = new System.Drawing.Size(140, 100); //Set the PictureBox Size property to 140,100
                    I.SizeMode = PictureBoxSizeMode.Zoom; //Stretch the image; maximum width and height are 140,100

                    ParcaPhotoDTO item = new ParcaPhotoDTO();
                    item.Miktar = _miktar;
                    item.Goruntu = I.Image;
                    item.ParcaKodu = ParcaIsmi[i];
                    parcaPhotoList.Add(item);
                }
            }

            iNumOfPastalFilesInPastalDirectory = ThumbnailsInFolder.Count;

            iPastalIndex = 0;


            Template.FileName = templatesInPastalDirectory[iPastalIndex];
        }
        catch { }
        return parcaPhotoList;
    }
    public static List<ParcaPhotoDTO> LoadAllThumbnails(string sTemplatesDirectoryNamePath, string _Pmalzeme, int _miktar)
    {
        List<ParcaPhotoDTO> parcaPhotoList = new List<ParcaPhotoDTO>();
        try
        {
            templatesInPastalDirectory = Directory.GetFiles(sTemplatesDirectoryNamePath, "*.dxf")
                                                              .OrderBy(filename => filename)
                                                              .ToArray();


            if (templatesInPastalDirectory.Length == 0)
            {
                DialogResult dr = MessageBox.Show("Seçilen Pastal klasörü içerisinde DXF dosyası bulunmamaktadır.", "PASTAL BİLGİSİ", MessageBoxButtons.OK);
                ParcaPhotoDTO item = new ParcaPhotoDTO();
                return parcaPhotoList;
            }

            string sThumbnailsDirectoryPath = sTemplatesDirectoryNamePath + "\\Thumbnails_cadviewer";

            //Initialize a new List of type Image as ImagesInFolder
            List<Image> ThumbnailsInFolder = new List<Image>();
            List<string> ParcaIsmi = new List<string>();
            //Initialize a new string of name PNGImages for every string in the string array returned from the given folder as files
            foreach (string PNGImages in Directory.GetFiles(sThumbnailsDirectoryPath, "*.png").OrderBy(filename => filename).ToArray())
            {
                Image image = Image.FromFile(PNGImages);
                string sPatternName = Path.GetFileNameWithoutExtension(PNGImages);
                //string sSubPatternName = sPatternName.Substring(3);
                float fFontSize = (float)(image.Width / 12);
                int iLengthPatternName = sPatternName.Length;
                if (iLengthPatternName > 16)
                {
                    fFontSize = fFontSize - 24;
                }
                if (fFontSize < 0)
                {
                    fFontSize = 15;
                }
                // Create graphics from image
                Graphics graphics = Graphics.FromImage(image);
                // Create font
                //Font font = new Font("Microsoft Sans Serif", fFontSize, FontStyle.Bold);
                Font font = new Font("Microsoft Sans Serif", fFontSize, FontStyle.Regular);
                // Draw text
                //graphics.DrawString(sPatternName, font, Brushes.DarkBlue, point);
                //graphics.DrawString(sPatternName, font, Brushes.DarkBlue, new PointF(0, 100.0F));
                graphics.DrawString(sPatternName, font, Brushes.DarkBlue, new PointF(0, image.Height - (fFontSize * 1.3F)));
                //graphics.DrawString(sPatternName, font, Brushes.DarkBlue, new PointF(0, image.Height - (fFontSize * 1.3F)));
                ThumbnailsInFolder.Add(image); //Add the Image gathered to the List collection
                ParcaIsmi.Add(PNGImages.Remove(0, PNGImages.LastIndexOf("\\") + 1).Replace(".png", ""));
            }

            int x = 0;
            int y = 0;
            for (int i = 0; i < ThumbnailsInFolder.Count; i++)
            {
                PictureBox I = new PictureBox(); //Initialize a new PictureBox of name I
                I.Tag = ParcaIsmi[i] + "~" + _Pmalzeme;
                I.Location = new System.Drawing.Point(x, y); //Set the PictureBox location to x,y
                x += 100; //Sort horizontally; Increment x by 100
                          //y += 50; //Sort vertically; Increment y by 50
                I.Image = ThumbnailsInFolder[i]; //Set the Image property of I to i in ImagesInFolder as index
                                                 //I.Size = new System.Drawing.Size(110, 110); //Set the PictureBox Size property to 110,100
                I.Size = new System.Drawing.Size(110, 100); //Set the PictureBox Size property to 110,100
                                                            //I.Size = new System.Drawing.Size(140, 100); //Set the PictureBox Size property to 140,100
                I.SizeMode = PictureBoxSizeMode.Zoom; //Stretch the image; maximum width and height are 140,100

                ///// aynı malzemeye ait siparişlere boom sonrası görselleri kopyalıyor
                //foreach (var item in GridDto.PlanliSiparisListesi.Where(z => z.SECIM))
                //{

                //    if (item.ProjeMalzeme == kilifReferans)
                //    {
                //        GridDto.PhotoVariable yeni = new GridDto.PhotoVariable();
                //        yeni.Gorsel = I.Image;
                //        yeni.Miktar = _miktar;
                //        yeni.ParcaKodu = ParcaIsmi[i];
                //        yeni.KilifReferans = kilifReferans;
                //        yeni.Siparis = item.ISEMRI;
                //        GridDto.BoomListesi.Add(yeni);
                //    }
                //}

                ParcaPhotoDTO item = new ParcaPhotoDTO();
                item.Miktar = _miktar;
                item.Goruntu = I.Image;
                item.ParcaKodu = ParcaIsmi[i];
                parcaPhotoList.Add(item);
            }

            iNumOfPastalFilesInPastalDirectory = ThumbnailsInFolder.Count;

            iPastalIndex = 0;


            Template.FileName = templatesInPastalDirectory[iPastalIndex];

        }
        catch { }
        return parcaPhotoList;
    }
    public class ParcaPhotoDTO
    {
        public string ParcaKodu { get; set; }
        public int Miktar { get; set; }
        public Image Goruntu { get; set; }
    }
    #endregion
}
