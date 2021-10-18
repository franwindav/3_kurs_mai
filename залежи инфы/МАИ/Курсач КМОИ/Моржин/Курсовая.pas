unit Курсовая;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms;

type
  TFrScheme = class(TFrame)
    N2: TMenuItem;
    FCImport1: TFrContainer;
    Import1: TImportFrame;
    GTransf1: TIPLTransform;
    FCGTransf1: TFrContainer;
    GTransf2: TIPLTransform;
    FCGTransf2: TFrContainer;
    Frag1: TFragmentFrame;
    FCFrag1: TFrContainer;
    NonLin1: TIPLNonLinearFrame;
    FCNonLin1: TFrContainer;
    ALU1: TIPLALUTwoFrame;
    FCALU1: TFrContainer;
    Hist1: THistogramFrame;
    FCHist1: TFrContainer;
    HistBin1: THistThreshFrame;
    FCHistBin1: TFrContainer;
    Binary1: TBinarizationFrame;
    FCBinary1: TFrContainer;
    Label1: TConnectivityFrame;
    FCLabel1: TFrContainer;
    ConAn1: TConAnalysisFrame;
    FCConAn1: TFrContainer;
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FrScheme1: TFrScheme;

implementation

{$R *.DFM}

end.
