using atelLibDXF.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;


public class TemplateClass
{
    public TemplateClass()
    {
    }

    private Image _image;

    private string _sTemplatesMainPath = "";
    private string _sFileName = "";

    private string _sTemplateName = "";

    #region Info from web service
    // PASTAL (from Web service)
    private string _sPastalCode = "";
    private string _sPastalDefinition = "";
    private string _sPastalMaterialCode = "";
    private string _sPastalMaterialDefinition = "";
    //private string _sPastalTDLINEDefinition = "";
    private string _sPastalProjectDefinion = "";
    private string _PastalCuttingNote = "";

    private string _sSpreadingDirection = "";
    private string _sSpreadingDirectionText = "";
    private string _sTextureDirection = "";
    private string _sTextureDirectionNote = "";

    private float _fDiameter_Drill01; // mm
    private float _fDiameter_Drill02; // mm
    private float _fVerev;

    private int _iNumOfTemplatesInPastal = 0;
    #endregion


    private float _fEnlargedOuterPolygonDistanceInMM = 2.0F; // mm
    private float _fReducedOuterPolygonDistanceInMM = 2.0F;  // mm

    private float _fEnlargedDrillHolePolygonDistanceInMM = 1.0F; // in mm
    private float _fReducedDrillHolePolygonDistanceInMM = 1.0F;  // in mm

    private float _fScaleCoefficientMin = 4.0F;
    private float _fScaleCoefficientMax = 100.0F;
    private float _fScaleCoefficient = 40.00F; // cm -> pixel
    private float _fScaleCoefficientX = 40.00F; // cm -> pixel
    private float _fScaleCoefficientY = 40.00F; // cm -> pixel

    // Correction for Y
    private float _fCorrectionCoefficientXYMin = 0.000001F;
    private float _fCorrectionCoefficientXYMax = 2.000000F;
    private float _fCorrectionCoefficientXY = 1.0F;
    private float _fCorrectionCoefficientXYStep = 0.000001F;

    private float _fWatermarkSizeFactor = 0.5F;

    private float _fDrawingPenWidth = 2.00F;
    private float _fMeasurementPenWidth = 0.50F;

    private float _fBigScaleStep = 5.00F;
    private float _fMiddleScaleStep = 1.00F;
    private float _fSmallScaleStep = 0.01F;

    private int _iX_AxisLength = 200; // in cm
    private int _iY_AxisLength = 150; // in cm

    private int _iDrawingAreaWidth;
    private int _iDrawingAreaHeight;

    private float _fMarkingsLength = 25.0F;

    private float _fMinX = 2000.0F;
    private float _fMinY = 2000.0F;
    private float _fMaxX = 0.0F;
    private float _fMaxY = 0.0F;

    private float _fWidth = 0.0F;
    private float _fHeight = 0.0F;

    private float _fDX_BordersSpacing = 3.0f;  // 3cm from left and 3 cm from right
    private float _fDY_BordersSpacing = 3.0f;  // 3cm from top and 3 cm from bottom

    private float _fRotationAngleInDegrees = 0.0F;
    private float _fRotationAngleStepInDegrees = 90.0F;

    private float _fMinV_cit_linelength = 0.7F;

    //private int _iNumOfDrills = 0;
    //private int _iNumOf_V_cits = 0;
    //private int _iNumOf_I_cits = 0;

    private Color _Region_1_Color;
    private Color _Region_2_Color;
    private Color _Region_3_Color;
    private Color _Region_4_Color;

    private bool _bHasAirbag = false;

    public bool HasAirbag
    {
        get { return _bHasAirbag; }
        set { _bHasAirbag = value; }
    }

    public Image image
    {
        get { return _image; }
        set { _image = value; }
    }

    public string TemplatesMainPath
    {
        get { return this._sTemplatesMainPath; }
        set { this._sTemplatesMainPath = value; }
    }

    public string FileName
    {
        get { return this._sFileName; }
        set { this._sFileName = value; }
    }

    public string TemplateName
    {
        get { return this._sTemplateName; }
        set { this._sTemplateName = value; }
    }

    // PASTAL (from Web service)
    public string PastalCode
    {
        get { return this._sPastalCode; }
        set { this._sPastalCode = value; }
    }

    public string PastalDefinition
    {
        get { return this._sPastalDefinition; }
        set { this._sPastalDefinition = value; }
    }

    public string PastalMaterialCode
    {
        get { return this._sPastalMaterialCode; }
        set { this._sPastalMaterialCode = value; }
    }


    public string PastalMaterialDefinition
    {
        get { return this._sPastalMaterialDefinition; }
        set { this._sPastalMaterialDefinition = value; }
    }

    //public string PastalTDLINEDefinition
    //{
    //    get { return this._sPastalMaterialDefinition; }
    //    set { this._sPastalMaterialDefinition = value; }
    //}

    public string PastalProjectDefinion
    {
        get { return this._sPastalProjectDefinion; }
        set { this._sPastalProjectDefinion = value; }
    }

    public string PastalCuttingNote
    {
        get { return this._PastalCuttingNote; }
        set { this._PastalCuttingNote = value; }
    }

    public string SpreadingDirection
    {
        get { return this._sSpreadingDirection; }
        set { this._sSpreadingDirection = value; }
    }

    public string SpreadingDirectionText
    {
        get { return this._sSpreadingDirectionText; }
        set { this._sSpreadingDirectionText = value; }
    }

    public string TextureDirection
    {
        get { return this._sTextureDirection; }
        set { this._sTextureDirection = value; }
    }

    public string TextureDirectionNote
    {
        get { return this._sTextureDirectionNote; }
        set { this._sTextureDirectionNote = value; }
    }

    public float Diameter_Drill01
    {
        get { return this._fDiameter_Drill01; }
        set { this._fDiameter_Drill01 = value; }
    }

    public float Diameter_Drill02
    {
        get { return this._fDiameter_Drill02; }
        set { this._fDiameter_Drill02 = value; }
    }

    public float Verev
    {
        get { return this._fVerev; }
        set { this._fVerev = value; }
    }

    public int DrawingAreaWidth
    {
        get { return this._iDrawingAreaWidth; }
        set { this._iDrawingAreaWidth = value; }
    }

    public int DrawingAreaHeight
    {
        get { return this._iDrawingAreaHeight; }
        set { this._iDrawingAreaHeight = value; }
    }

    public int NumOfTemplatesInPastal
    {
        get { return this._iNumOfTemplatesInPastal; }
        set { this._iNumOfTemplatesInPastal = value; }
    }

    public float EnlargedOuterPolygonDistanceInMM
    {
        get { return this._fEnlargedOuterPolygonDistanceInMM; }
        set { this._fEnlargedOuterPolygonDistanceInMM = value; }
    }

    public float ReducedOuterPolygonDistanceInMM
    {
        get { return this._fReducedOuterPolygonDistanceInMM; }
        set { this._fReducedOuterPolygonDistanceInMM = value; }
    }

    public float EnlargedDrillHolePolygonDistanceInMM
    {
        get { return this._fEnlargedDrillHolePolygonDistanceInMM; }
        set { this._fEnlargedDrillHolePolygonDistanceInMM = value; }
    }

    public float ReducedDrillHolePolygonDistanceInMM
    {
        get { return this._fReducedDrillHolePolygonDistanceInMM; }
        set { this._fReducedDrillHolePolygonDistanceInMM = value; }
    }

    public float ScaleCoefficientMin
    {
        get { return this._fScaleCoefficientMin; }
        set { this._fScaleCoefficientMin = value; }
    }

    public float ScaleCoefficientMax
    {
        get { return this._fScaleCoefficientMax; }
        set { this._fScaleCoefficientMax = value; }
    }

    public float ScaleCoefficient
    {
        get { return this._fScaleCoefficient; }
        set { this._fScaleCoefficient = value; }
    }

    public float ScaleCoefficientX
    {
        get { return this._fScaleCoefficientX; }
        set { this._fScaleCoefficientX = value; }
    }

    public float ScaleCoefficientY
    {
        get { return this._fScaleCoefficientY; }
        set { this._fScaleCoefficientY = value; }
    }

    public float CorrectionCoefficientXY
    {
        get { return this._fCorrectionCoefficientXY; }
        set { this._fCorrectionCoefficientXY = value; }
    }

    public float CorrectionCoefficientXYStep
    {
        get { return this._fCorrectionCoefficientXYStep; }
        set { this._fCorrectionCoefficientXYStep = value; }
    }

    public float CorrectionCoefficientXYMin
    {
        get { return this._fCorrectionCoefficientXYMin; }
        set { this._fCorrectionCoefficientXYMin = value; }
    }

    public float CorrectionCoefficientXYMax
    {
        get { return this._fCorrectionCoefficientXYMax; }
        set { this._fCorrectionCoefficientXYMax = value; }
    }

    public float WatermarkSizeFactor
    {
        get { return this._fWatermarkSizeFactor; }
        set { this._fWatermarkSizeFactor = value; }
    }

    public float DrawingPenWidth
    {
        get { return this._fDrawingPenWidth; }
        set { this._fDrawingPenWidth = value; }
    }

    public float MeasurementPenWidth
    {
        get { return this._fMeasurementPenWidth; }
        set { this._fMeasurementPenWidth = value; }
    }

    public float BigScaleStep
    {
        get { return this._fBigScaleStep; }
        set { this._fBigScaleStep = value; }
    }

    public float MiddleScaleStep
    {
        get { return this._fMiddleScaleStep; }
        set { this._fMiddleScaleStep = value; }
    }

    public float SmallScaleStep
    {
        get { return this._fSmallScaleStep; }
        set { this._fSmallScaleStep = value; }
    }

    public int X_AxisLength
    {
        get { return this._iX_AxisLength; }
        set { this._iX_AxisLength = value; }
    }

    public int Y_AxisLength
    {
        get { return this._iY_AxisLength; }
        set { this._iY_AxisLength = value; }
    }

    public float MarkingsLength
    {
        get { return this._fMarkingsLength; }
        set { this._fMarkingsLength = value; }
    }

    public float MinX
    {
        get { return this._fMinX; }
        set { this._fMinX = value; }
    }

    public float MinY
    {
        get { return this._fMinY; }
        set { this._fMinY = value; }
    }

    public float MaxX
    {
        get { return this._fMaxX; }
        set { this._fMaxX = value; }
    }

    public float MaxY
    {
        get { return this._fMaxY; }
        set { this._fMaxY = value; }
    }

    public float Width
    {
        get { return this._fWidth; }
        set { this._fWidth = value; }
    }

    public float Height
    {
        get { return this._fHeight; }
        set { this._fHeight = value; }
    }

    public float X_BordersSpacing
    {
        get { return this._fDX_BordersSpacing; }
        set { this._fDX_BordersSpacing = value; }
    }

    public float Y_BordersSpacing
    {
        get { return this._fDY_BordersSpacing; }
        set { this._fDY_BordersSpacing = value; }
    }

    public float RotationAngleStepInDegrees
    {
        get { return this._fRotationAngleStepInDegrees; }
        set { this._fRotationAngleStepInDegrees = value; }
    }

    public float RotationAngleInDegrees
    {
        get { return this._fRotationAngleInDegrees; }
        set { this._fRotationAngleInDegrees = value; }
    }

    public float MinV_cit_linelength
    {
        get { return this._fMinV_cit_linelength; }
        set { this._fMinV_cit_linelength = value; }
    }

    public int NumOfDrills
    {
        get { return this._Circles.Count; }
    }

    public int NumOf_V_cits
    {
        get { return this._V_cits.Count; }
    }

    public int NumOf_I_cits
    {
        get { return this._I_cits.Count; }
    }

    public Color Region_1_Color
    {
        get { return this._Region_1_Color; }
        set { this._Region_1_Color = value; }
    }

    public Color Region_2_Color
    {
        get { return this._Region_2_Color; }
        set { this._Region_2_Color = value; }
    }

    public Color Region_3_Color
    {
        get { return this._Region_3_Color; }
        set { this._Region_3_Color = value; }
    }

    public Color Region_4_Color
    {
        get { return this._Region_4_Color; }
        set { this._Region_4_Color = value; }
    }

    private List<Polyline> _Polylines = new List<Polyline>();
    private List<Polyline> _Circles = new List<Polyline>();
    private List<Line> _Lines = new List<Line>();

    private List<string> _PartTexts = new List<string>();

    private Text _text = new Text();

    private Line _DirectionLine = new Line();

    private List<Polyline> _I_cits = new List<Polyline>();
    private List<Polyline> _V_cits = new List<Polyline>();

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public List<Polyline> Polylines
    {
        get { return _Polylines; }
        set { _Polylines = value; }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public List<Polyline> Circles
    {
        get { return _Circles; }
        set { _Circles = value; }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public List<Line> Lines
    {
        get { return _Lines; }
        set { _Lines = value; }
    }

    public List<string> PartsTexts
    {
        get { return _PartTexts; }
        set { _PartTexts = value; }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public Text text
    {
        get { return _text; }
        set { _text = value; }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public Line DirectionLine
    {
        get { return _DirectionLine; }
        set { _DirectionLine = value; }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public List<Polyline> I_Cits
    {
        get { return _I_cits; }
        set { _I_cits = value; }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public List<Polyline> V_Cits
    {
        get { return _V_cits; }
        set { _V_cits = value; }
    }
}

