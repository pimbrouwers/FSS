namespace Fss

open Fable.Core

[<AutoOpen>]
module Column =
    let private columnGapToString (gap: FssTypes.IColumnGap) =
        match gap with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | _ -> "Unknown column gap"

    let private columnSpanToString (span: FssTypes.IColumnSpan) =
        let stringifyColumnSpan =
            function
                | FssTypes.Column.Span.All -> "all"

        match span with
        | :? FssTypes.Column.Span as c -> stringifyColumnSpan c
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown column span"

    let private columnsToString(columns: FssTypes.IColumns) =
        match columns with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown columns"

    let private columnRuleToString(columnRule: FssTypes.IColumnRule) =
        match columnRule with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column rule"

    let private columnRuleWidthToString (ruleWidth: FssTypes.IColumnRuleWidth) =
        match ruleWidth with
        | :? FssTypes.Column.RuleWidth as w -> Utilities.Helpers.duToLowercase w
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column rule width"

    let private columnRuleStyleToString (style: FssTypes.IColumnRuleStyle) =
        match style with
        | :? FssTypes.Column.RuleStyle as b -> Utilities.Helpers.duToLowercase b
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column style"

    let private columnRuleColorToString (columnColor: FssTypes.IColumnRuleColor) =
        match columnColor with
        | :? FssTypes.Color.ColorType as c -> FssTypes.Color.colorHelpers.colorToString c
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column rule color"

    let private columnCountToString (columnCount: FssTypes.IColumnCount) =
        match columnCount with
        | :? FssTypes.CssInt as i -> FssTypes.masterTypeHelpers.IntToString i
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column count"

    let private columnFillToString (columnFill: FssTypes.IColumnFill) =
        match columnFill with
        | :? FssTypes.Column.Fill as c -> Utilities.Helpers.duToKebab c
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column fill"

    let private columnWidthToString (columnWidth: FssTypes.IColumnWidth) =
        match columnWidth with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column width"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-gap
    let private columnGapValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnGap
    let private columnGapValue' = columnGapToString >> columnGapValue
    [<Erase>]
    type ColumnGap =
        static member Value (gap: FssTypes.IColumnGap) = gap |> columnGapValue'
        static member inherit' = FssTypes.Inherit |> columnGapValue'
        static member initial = FssTypes.Initial |> columnGapValue'
        static member unset = FssTypes.Unset |> columnGapValue'
        static member normal = FssTypes.Normal |> columnGapValue'

    /// <summary>Sets gap width between element.</summary>
    /// <param name="columnGap">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnGap' = ColumnGap.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-span
    let private columnSpanValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnSpan
    let private columnSpanValue' = columnSpanToString >> columnSpanValue

    [<Erase>]
    type ColumnSpan =
        static member value(span: FssTypes.IColumnSpan) = span |> columnSpanValue'
        static member all = FssTypes.Column.Span.All |> columnSpanValue'
        static member inherit' = FssTypes.Inherit |> columnSpanValue'
        static member initial = FssTypes.Initial |> columnSpanValue'
        static member unset = FssTypes.Unset |> columnSpanValue'
        static member none = FssTypes.None' |> columnSpanValue'

    /// <summary>Sets gap width between element.</summary>
    /// <param name="span">
    ///     can be:
    ///     - <c> ColumnSpan </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnSpan' = ColumnSpan.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/columns
    let private columnsValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Columns
    let private columnsValue' = columnsToString >> columnsValue

    [<Erase>]
    type Columns =
        static member value (columns: FssTypes.IColumns) = columns |> columnsValue'
        static member inherit' = FssTypes.Inherit |> columnsValue'
        static member initial = FssTypes.Initial |> columnsValue'
        static member unset = FssTypes.Unset |> columnsValue'

    /// <summary>Resets columns.</summary>
    /// <param name="columns">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Columns' = Columns.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule
    let private columnRuleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnRule
    let private columnRuleValue' = columnRuleToString >> columnRuleValue

    [<Erase>]
    type ColumnRule =
        static member value (rule: FssTypes.IColumnRule) = rule |> columnRuleValue'
        static member inherit' = FssTypes.Inherit |> columnRuleValue'
        static member initial = FssTypes.Initial |> columnRuleValue'
        static member unset = FssTypes.Unset |> columnRuleValue'

    /// <summary>Resets column rule.</summary>
    /// <param name="rule">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnRule' = ColumnRule.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-width
    let private columnRuleWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnRuleWidth
    let private columnRuleWidthValue' = columnRuleWidthToString >> columnRuleWidthValue

    [<Erase>]
    type ColumnRuleWidth =
        static member value (ruleWidth: FssTypes.IColumnRuleWidth) = ruleWidth |> columnRuleWidthValue'
        static member thin = FssTypes.Column.RuleWidth.Thin |> columnRuleWidthValue'
        static member medium = FssTypes.Column.RuleWidth.Medium |> columnRuleWidthValue'
        static member thick = FssTypes.Column.RuleWidth.Thick |> columnRuleWidthValue'
        static member inherit' = FssTypes.Inherit |> columnRuleWidthValue'
        static member initial = FssTypes.Initial |> columnRuleWidthValue'
        static member unset = FssTypes.Unset |> columnRuleWidthValue'

    /// <summary>Specifies width of the line drawn between columns.</summary>
    /// <param name="ruleWidth">
    ///     can be:
    ///     - <c> ColumnRuleWidth </c>
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnRuleWidth' = ColumnRuleWidth.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-style
    let private styleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnRuleStyle
    let private styleValue' = columnRuleStyleToString >> styleValue

    [<Erase>]
    type ColumnRuleStyle =
        static member value (style: FssTypes.IColumnRuleStyle) = style |> styleValue'
        static member hidden = FssTypes.Column.RuleStyle.Hidden |> styleValue'
        static member dotted = FssTypes.Column.RuleStyle.Dotted |> styleValue'
        static member dashed = FssTypes.Column.RuleStyle.Dashed |> styleValue'
        static member solid = FssTypes.Column.RuleStyle.Solid |> styleValue'
        static member double = FssTypes.Column.RuleStyle.Double |> styleValue'
        static member groove = FssTypes.Column.RuleStyle.Groove |> styleValue'
        static member ridge = FssTypes.Column.RuleStyle.Ridge |> styleValue'
        static member inset = FssTypes.Column.RuleStyle.Inset |> styleValue'
        static member outset = FssTypes.Column.RuleStyle.Outset |> styleValue'

        static member none = FssTypes.None' |> styleValue'
        static member inherit' = FssTypes.Inherit |> styleValue'
        static member initial = FssTypes.Initial |> styleValue'
        static member unset = FssTypes.Unset |> styleValue'

    /// <summary>Specifies style of the line drawn between columns.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> ColumnRuleStyle </c>
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnRuleStyle' = ColumnRuleStyle.value

     // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-color
    let private columnRuleColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnRuleColor
    let private columnRuleColorValue' = columnRuleColorToString >> columnRuleColorValue

    let ColumnRuleColor = FssTypes.ColumnRuleColorClass(columnRuleColorValue')

    /// <summary>Specifies color of the line drawn between columns.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnRuleColor' = ColumnRuleColor.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-count
    let private columnCountValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnCount
    let private columnCountValue' = columnCountToString >> columnCountValue

    [<Erase>]
    type ColumnCount =
        static member value(columnCount: FssTypes.IColumnCount) = columnCount |> columnCountValue'
        static member auto = FssTypes.Auto |> columnCountValue'
        static member inherit' = FssTypes.Inherit |> columnCountValue'
        static member initial = FssTypes.Initial |> columnCountValue'
        static member unset = FssTypes.Unset |> columnCountValue'

    /// <summary>Specifies number of column to break content into.</summary>
    /// <param name="columnCount">
    ///     can be:
    ///     - <c> CssInt </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnCount' = ColumnCount.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-fill
    let private columnFillValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnFill
    let private columnFillValue' = columnFillToString >> columnFillValue

    [<Erase>]
    type ColumnFill =
        static member value(columnFill: FssTypes.IColumnFill) = columnFill |> columnFillValue'
        static member balance = FssTypes.Column.Fill.Balance |> columnFillValue'
        static member balanceAll = FssTypes.Column.Fill.BalanceAll |> columnFillValue'
        static member auto = FssTypes.Auto |> columnFillValue'
        static member inherit' = FssTypes.Inherit |> columnFillValue'
        static member initial = FssTypes.Initial |> columnFillValue'
        static member unset = FssTypes.Unset |> columnFillValue'

    /// <summary>Specifies how content fills columns.</summary>
    /// <param name="columnFill">
    ///     can be:
    ///     - <c> ColumnFill </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnFill' = ColumnFill.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-width
    let private columnWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnWidth
    let private columnWidthValue' = columnWidthToString >> columnWidthValue

    [<Erase>]
    type ColumnWidth =
        static member value(columnWidth: FssTypes.IColumnWidth) = columnWidth |> columnWidthValue'
        static member auto = FssTypes.Auto |> columnWidthValue'
        static member inherit' = FssTypes.Inherit |> columnWidthValue'
        static member initial = FssTypes.Initial |> columnWidthValue'
        static member unset = FssTypes.Unset |> columnWidthValue'

    /// <summary>Specifies width of line drawn between column.</summary>
    /// <param name="columnWidth">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnWidth' = ColumnWidth.value