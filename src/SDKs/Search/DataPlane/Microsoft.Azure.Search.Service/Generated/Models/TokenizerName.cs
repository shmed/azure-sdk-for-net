// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for TokenizerName.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TokenizerName
    {
        [EnumMember(Value = "classic")]
        Classic,
        [EnumMember(Value = "edgeNGram")]
        EdgeNGram,
        [EnumMember(Value = "keyword_v2")]
        KeywordV2,
        [EnumMember(Value = "letter")]
        Letter,
        [EnumMember(Value = "lowercase")]
        Lowercase,
        [EnumMember(Value = "microsoft_language_tokenizer")]
        MicrosoftLanguageTokenizer,
        [EnumMember(Value = "microsoft_language_stemming_tokenizer")]
        MicrosoftLanguageStemmingTokenizer,
        [EnumMember(Value = "nGram")]
        NGram,
        [EnumMember(Value = "path_hierarchy_v2")]
        PathHierarchyV2,
        [EnumMember(Value = "pattern")]
        Pattern,
        [EnumMember(Value = "standard_v2")]
        StandardV2,
        [EnumMember(Value = "uax_url_email")]
        UaxUrlEmail,
        [EnumMember(Value = "whitespace")]
        Whitespace
    }
    internal static class TokenizerNameEnumExtension
    {
        internal static string ToSerializedValue(this TokenizerName? value)
        {
            return value == null ? null : ((TokenizerName)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this TokenizerName value)
        {
            switch( value )
            {
                case TokenizerName.Classic:
                    return "classic";
                case TokenizerName.EdgeNGram:
                    return "edgeNGram";
                case TokenizerName.KeywordV2:
                    return "keyword_v2";
                case TokenizerName.Letter:
                    return "letter";
                case TokenizerName.Lowercase:
                    return "lowercase";
                case TokenizerName.MicrosoftLanguageTokenizer:
                    return "microsoft_language_tokenizer";
                case TokenizerName.MicrosoftLanguageStemmingTokenizer:
                    return "microsoft_language_stemming_tokenizer";
                case TokenizerName.NGram:
                    return "nGram";
                case TokenizerName.PathHierarchyV2:
                    return "path_hierarchy_v2";
                case TokenizerName.Pattern:
                    return "pattern";
                case TokenizerName.StandardV2:
                    return "standard_v2";
                case TokenizerName.UaxUrlEmail:
                    return "uax_url_email";
                case TokenizerName.Whitespace:
                    return "whitespace";
            }
            return null;
        }

        internal static TokenizerName? ParseTokenizerName(this string value)
        {
            switch( value )
            {
                case "classic":
                    return TokenizerName.Classic;
                case "edgeNGram":
                    return TokenizerName.EdgeNGram;
                case "keyword_v2":
                    return TokenizerName.KeywordV2;
                case "letter":
                    return TokenizerName.Letter;
                case "lowercase":
                    return TokenizerName.Lowercase;
                case "microsoft_language_tokenizer":
                    return TokenizerName.MicrosoftLanguageTokenizer;
                case "microsoft_language_stemming_tokenizer":
                    return TokenizerName.MicrosoftLanguageStemmingTokenizer;
                case "nGram":
                    return TokenizerName.NGram;
                case "path_hierarchy_v2":
                    return TokenizerName.PathHierarchyV2;
                case "pattern":
                    return TokenizerName.Pattern;
                case "standard_v2":
                    return TokenizerName.StandardV2;
                case "uax_url_email":
                    return TokenizerName.UaxUrlEmail;
                case "whitespace":
                    return TokenizerName.Whitespace;
            }
            return null;
        }
    }
}
