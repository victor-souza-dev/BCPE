using System.Text.RegularExpressions;

namespace ExtractCssValuesToJson.Models {
    public class ExtractProperty {
        private readonly string cssContent;
        private readonly List<FormatConfigCss> mappings;
        private readonly Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        private readonly string fileName;

        public ExtractProperty(string fileName, string cssContent, List<FormatConfigCss> mappings) {
            this.fileName = fileName;
            this.cssContent = cssContent;
            this.mappings = mappings;
        }

        public Dictionary<string, string> ExtractProperties() {
            foreach (var mapping in mappings) {
                foreach (var keyValue in mapping.KeyValue) {
                    ExtractPropertyFromCss(keyValue, mapping.ClassName);
                }
            }

            return keyValuePairs;
        }

        private void ExtractPropertyFromCss(KeyValueCss keyValue, string className) {
            string pattern = $@"\{className}\s*{{\s*([^}}]+)\s*}}";
            try {
                Match match = Regex.Match(cssContent, pattern, RegexOptions.Singleline);

                if (!match.Success) {
                    string idMessage = $"Identifier {className} not found!";
                    throw new Exception($"{fileName}: {idMessage}");
                }

                string contentMatch = match.Groups[1].Value;

                switch (keyValue.Property.ToLower()) {
                    case "background-color":
                        ExBgColor(contentMatch, keyValue.ResultName);
                        break;
                    case "font-family":
                        ExFontFamily(contentMatch, keyValue.ResultName);
                        break;
                    case "color":
                        ExColor(contentMatch, keyValue.ResultName);
                        break;
                    default:
                        ExtractGenericProperty(contentMatch, keyValue.Property, keyValue.ResultName.Replace(" ", "_"));
                        break;
                }
            } catch(Exception ex) {
                bool propMessage = ex.Message.Contains("Property");
                string idMessage = $"Identifier {className} not found!";
                string message = propMessage ? ex.Message : idMessage;

                throw new Exception($"{fileName}: {message}");
            }
        }

        private void ExtractGenericProperty(string content, string propertyName, string index) {
            string pattern = $@"{Regex.Escape(propertyName)}:\s*([^;!]+)\s*(;|!)?";
            Match matchProp = Regex.Match(content, pattern, RegexOptions.IgnoreCase);


            if(matchProp.Success) {
                string prop = matchProp.Groups[1].Value.Trim();
                keyValuePairs[index] = prop;
            } else {
                throw new Exception($"Property {propertyName} not found or invalid!");
            }
        }

        private void ExBgColor(string content, string index) {
            string pattern = @"background-color:\s*([^;!]+)\s*(;|!)?";
            Match matchProp = Regex.Match(content, pattern);

            if(matchProp.Success) {
                string prop = matchProp.Groups[1].Value.Replace(" ", "").Trim();
                keyValuePairs[index] = prop;
            } else {
                throw new Exception($"Property background-color not found or invalid!");
            }

        }

        private void ExFontFamily(string content, string index) {
            string pattern = @"font-family:\s*([^;!]+)\s*(;|!)?";
            Match matchProp = Regex.Match(content, pattern, RegexOptions.Singleline);
            
            if(matchProp.Success) {
                string prop = matchProp.Groups[1].Value.Replace("\"Roboto\"", "").Replace(" ", "").Trim();
                keyValuePairs[index] = prop;
            } else {
                throw new Exception($"Property fonte-family not found or invalid!");
            }
        }

        private void ExColor(string content, string index) {
            string pattern = @"color:\s*([^;!]+)\s*(;|!)?";
            string contentModify = content.Replace("background-color", "").Replace("border-color", "");
            Match matchProp = Regex.Match(contentModify, pattern, RegexOptions.Singleline);

            if(matchProp.Success) {
                string prop = matchProp.Groups[1].Value.Replace("!important", "").Trim();
                keyValuePairs[index] = prop;
            } else {
                throw new Exception("Property color not found or invalid!");
            }
        }
    }
}