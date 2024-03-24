using System.Net;

namespace WCLDBUpdater;

class Deserializers
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class BackgroundColor
    {
        public int red { get; set; }
        public int green { get; set; }
        public int blue { get; set; }
    }

    public class BackgroundColorStyle
    {
        public RgbColor rgbColor { get; set; }
    }

    public class Color
    {
        public RgbColor rgbColor { get; set; }
    }

    public class ColumnMetadatum
    {
        public int pixelSize { get; set; }
    }

    public class Datum
    {
        public List<RowDatum> rowData { get; set; }
        public List<RowMetadatum> rowMetadata { get; set; }
        public List<ColumnMetadatum> columnMetadata { get; set; }
    }

    public class DefaultFormat
    {
        public BackgroundColor backgroundColor { get; set; }
        public Padding padding { get; set; }
        public string verticalAlignment { get; set; }
        public string wrapStrategy { get; set; }
        public TextFormat textFormat { get; set; }
        public BackgroundColorStyle backgroundColorStyle { get; set; }
    }

    public class EffectiveFormat
    {
        public BackgroundColor backgroundColor { get; set; }
        public Padding padding { get; set; }
        public string horizontalAlignment { get; set; }
        public string verticalAlignment { get; set; }
        public string wrapStrategy { get; set; }
        public TextFormat textFormat { get; set; }
        public string hyperlinkDisplayType { get; set; }
        public BackgroundColorStyle backgroundColorStyle { get; set; }
    }

    public class EffectiveValue
    {
        public string stringValue { get; set; }
    }

    public class ForegroundColor
    {
    }

    public class ForegroundColorStyle
    {
        public RgbColor rgbColor { get; set; }
    }

    public class GridProperties
    {
        public int rowCount { get; set; }
        public int columnCount { get; set; }
    }

    public class Padding
    {
        public int top { get; set; }
        public int right { get; set; }
        public int bottom { get; set; }
        public int left { get; set; }
    }

    public class Properties
    {
        public string title { get; set; }
        public string locale { get; set; }
        public string autoRecalc { get; set; }
        public string timeZone { get; set; }
        public DefaultFormat defaultFormat { get; set; }
        public SpreadsheetTheme spreadsheetTheme { get; set; }
        public int sheetId { get; set; }
        public int index { get; set; }
        public string sheetType { get; set; }
        public GridProperties gridProperties { get; set; }
    }

    public class RgbColor
    {
        public double red { get; set; }
        public double green { get; set; }
        public double blue { get; set; }
    }

    public class SpreadSheetDeserializer
    {
        public string spreadsheetId { get; set; }
        public Properties properties { get; set; }
        public List<Sheet> sheets { get; set; }
        public string spreadsheetUrl { get; set; }
    }

    public class RowDatum
    {
        public List<Value> values { get; set; }
    }

    public class RowMetadatum
    {
        public int pixelSize { get; set; }
    }

    public class Sheet
    {
        public Properties properties { get; set; }
        public List<Datum> data { get; set; }
    }

    public class SpreadsheetTheme
    {
        public string primaryFontFamily { get; set; }
        public List<ThemeColor> themeColors { get; set; }
    }

    public class TextFormat
    {
        public ForegroundColor foregroundColor { get; set; }
        public string fontFamily { get; set; }
        public int fontSize { get; set; }
        public bool bold { get; set; }
        public bool italic { get; set; }
        public bool strikethrough { get; set; }
        public bool underline { get; set; }
        public ForegroundColorStyle foregroundColorStyle { get; set; }
    }

    public class ThemeColor
    {
        public string colorType { get; set; }
        public Color color { get; set; }
    }

    public class UserEnteredValue
    {
        public string stringValue { get; set; }
    }

    public class Value
    {
        public UserEnteredValue userEnteredValue { get; set; }
        public EffectiveValue effectiveValue { get; set; }
        public string formattedValue { get; set; }
        public EffectiveFormat effectiveFormat { get; set; }
    }


}
