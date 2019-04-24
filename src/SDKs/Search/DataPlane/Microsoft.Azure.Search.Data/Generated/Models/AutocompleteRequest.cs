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
    using System.Linq;

    /// <summary>
    /// Parameters for fuzzy matching, and other autocomplete query behaviors.
    /// </summary>
    internal partial class AutocompleteRequest
    {
        /// <summary>
        /// Initializes a new instance of the AutocompleteRequest class.
        /// </summary>
        public AutocompleteRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AutocompleteRequest class.
        /// </summary>
        /// <param name="searchText">The search text on which to base
        /// autocomplete results.</param>
        /// <param name="autocompleteMode">Specifies the mode for Autocomplete.
        /// The default is 'oneTerm'. Use 'twoTerms' to get shingles and
        /// 'oneTermWithContext' to use the current context while producing
        /// auto-completed terms. Possible values include: 'oneTerm',
        /// 'twoTerms', 'oneTermWithContext'</param>
        /// <param name="filter">An OData expression that filters the documents
        /// used to produce completed terms for the Autocomplete
        /// result.</param>
        /// <param name="useFuzzyMatching">A value indicating whether to use
        /// fuzzy matching for the autocomplete query. Default is false. When
        /// set to true, the query will autocomplete terms even if there's a
        /// substituted or missing character in the search text. While this
        /// provides a better experience in some scenarios, it comes at a
        /// performance cost as fuzzy autocomplete queries are slower and
        /// consume more resources.</param>
        /// <param name="highlightPostTag">A string tag that is appended to hit
        /// highlights. Must be set with highlightPreTag. If omitted, hit
        /// highlighting is disabled.</param>
        /// <param name="highlightPreTag">A string tag that is prepended to hit
        /// highlights. Must be set with highlightPostTag. If omitted, hit
        /// highlighting is disabled.</param>
        /// <param name="minimumCoverage">A number between 0 and 100 indicating
        /// the percentage of the index that must be covered by an autocomplete
        /// query in order for the query to be reported as a success. This
        /// parameter can be useful for ensuring search availability even for
        /// services with only one replica. The default is 80.</param>
        /// <param name="searchFields">The comma-separated list of field names
        /// to consider when querying for auto-completed terms. Target fields
        /// must be included in the specified suggester.</param>
        /// <param name="suggesterName">The name of the suggester as specified
        /// in the suggesters collection that's part of the index
        /// definition.</param>
        /// <param name="top">The number of auto-completed terms to retrieve.
        /// This must be a value between 1 and 100. The default is 5.</param>
        public AutocompleteRequest(string searchText = default(string), AutocompleteMode? autocompleteMode = default(AutocompleteMode?), string filter = default(string), bool? useFuzzyMatching = default(bool?), string highlightPostTag = default(string), string highlightPreTag = default(string), double? minimumCoverage = default(double?), string searchFields = default(string), string suggesterName = default(string), int? top = default(int?))
        {
            SearchText = searchText;
            AutocompleteMode = autocompleteMode;
            Filter = filter;
            UseFuzzyMatching = useFuzzyMatching;
            HighlightPostTag = highlightPostTag;
            HighlightPreTag = highlightPreTag;
            MinimumCoverage = minimumCoverage;
            SearchFields = searchFields;
            SuggesterName = suggesterName;
            Top = top;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the search text on which to base autocomplete results.
        /// </summary>
        [JsonProperty(PropertyName = "search")]
        public string SearchText { get; set; }

        /// <summary>
        /// Gets or sets specifies the mode for Autocomplete. The default is
        /// 'oneTerm'. Use 'twoTerms' to get shingles and 'oneTermWithContext'
        /// to use the current context while producing auto-completed terms.
        /// Possible values include: 'oneTerm', 'twoTerms',
        /// 'oneTermWithContext'
        /// </summary>
        [JsonProperty(PropertyName = "autocompleteMode")]
        public AutocompleteMode? AutocompleteMode { get; set; }

        /// <summary>
        /// Gets or sets an OData expression that filters the documents used to
        /// produce completed terms for the Autocomplete result.
        /// </summary>
        [JsonProperty(PropertyName = "filter")]
        public string Filter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use fuzzy matching for
        /// the autocomplete query. Default is false. When set to true, the
        /// query will autocomplete terms even if there's a substituted or
        /// missing character in the search text. While this provides a better
        /// experience in some scenarios, it comes at a performance cost as
        /// fuzzy autocomplete queries are slower and consume more resources.
        /// </summary>
        [JsonProperty(PropertyName = "fuzzy")]
        public bool? UseFuzzyMatching { get; set; }

        /// <summary>
        /// Gets or sets a string tag that is appended to hit highlights. Must
        /// be set with highlightPreTag. If omitted, hit highlighting is
        /// disabled.
        /// </summary>
        [JsonProperty(PropertyName = "highlightPostTag")]
        public string HighlightPostTag { get; set; }

        /// <summary>
        /// Gets or sets a string tag that is prepended to hit highlights. Must
        /// be set with highlightPostTag. If omitted, hit highlighting is
        /// disabled.
        /// </summary>
        [JsonProperty(PropertyName = "highlightPreTag")]
        public string HighlightPreTag { get; set; }

        /// <summary>
        /// Gets or sets a number between 0 and 100 indicating the percentage
        /// of the index that must be covered by an autocomplete query in order
        /// for the query to be reported as a success. This parameter can be
        /// useful for ensuring search availability even for services with only
        /// one replica. The default is 80.
        /// </summary>
        [JsonProperty(PropertyName = "minimumCoverage")]
        public double? MinimumCoverage { get; set; }

        /// <summary>
        /// Gets or sets the comma-separated list of field names to consider
        /// when querying for auto-completed terms. Target fields must be
        /// included in the specified suggester.
        /// </summary>
        [JsonProperty(PropertyName = "searchFields")]
        public string SearchFields { get; set; }

        /// <summary>
        /// Gets or sets the name of the suggester as specified in the
        /// suggesters collection that's part of the index definition.
        /// </summary>
        [JsonProperty(PropertyName = "suggesterName")]
        public string SuggesterName { get; set; }

        /// <summary>
        /// Gets or sets the number of auto-completed terms to retrieve. This
        /// must be a value between 1 and 100. The default is 5.
        /// </summary>
        [JsonProperty(PropertyName = "top")]
        public int? Top { get; set; }

    }
}
