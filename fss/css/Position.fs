namespace Fss

open Fable.Core

// https://developer.mozilla.org/en-US/docs/Web/CSS/position
[<AutoOpen>]
module Position =

    let private positionedToString (positioned: FssTypes.IPositioned) =
        match positioned with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ ->  "Unknown position"

    let private verticalAlignToString (alignment: FssTypes.IVerticalAlign) =
        match alignment with
        | :? FssTypes.Position.VerticalAlign as v -> Utilities.Helpers.duToKebab v
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | _ -> "Unknown vertical align"

    let private floatToString (float: FssTypes.IFloat) =
        match float with
        | :? FssTypes.Position.Float as v -> Utilities.Helpers.duToKebab v
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown float"

    let private directionToString (direction: FssTypes.IDirection) =
        match direction with
        | :? FssTypes.Position.Direction as d -> Utilities.Helpers.duToLowercase d
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown direction"

    let private positionValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Position
    let private positionValue' = Utilities.Helpers.duToKebab >> positionValue

    [<Erase>]
    type Position =
        static member value(position: FssTypes.Position.Position) = position |> positionValue'
        static member static' = FssTypes.Position.Static |> positionValue'
        static member relative = FssTypes.Position.Relative |> positionValue'
        static member absolute = FssTypes.Position.Absolute |> positionValue'
        static member sticky = FssTypes.Position.Sticky |> positionValue'
        static member fixed' = FssTypes.Position.Fixed |> positionValue'

    /// <summary>Specifies how an element is to be positioned.</summary>
    /// <param name="position">How to position element</param>
    /// <returns>Css property for fss.</returns>
    let Position' (position: FssTypes.Position.Position) = Position.value(position)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/top
    let private topValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Top
    let private topValue' = positionedToString >> topValue

    [<Erase>]
    type Top =
        static member value (top: FssTypes.IPositioned) = top |> topValue'
        static member auto = FssTypes.Auto |> topValue'
        static member inherit' = FssTypes.Inherit |> topValue'
        static member initial = FssTypes.Initial |> topValue'
        static member unset = FssTypes.Unset |> topValue'

    /// <summary>Specifies vertical position of element.</summary>
    /// <param name="top">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Top' = Top.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/right
    let private rightValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Right
    let private rightValue' = positionedToString >> rightValue

    [<Erase>]
    type Right =
        static member value (right: FssTypes.IPositioned) = right |> rightValue'

        static member auto = FssTypes.Auto |> rightValue'
        static member inherit' = FssTypes.Inherit |> rightValue'
        static member initial = FssTypes.Initial |> rightValue'
        static member unset = FssTypes.Unset |> rightValue'

    /// <summary>Specifies horizontal position of element.</summary>
    /// <param name="right">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Right' = Right.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/bottom
    let private bottomValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Bottom
    let private bottomValue' = positionedToString >> bottomValue

    [<Erase>]
    type Bottom =
        static member value (bottom: FssTypes.IPositioned) = bottom |> bottomValue'

        static member auto = FssTypes.Auto |> bottomValue'
        static member inherit' = FssTypes.Inherit |> bottomValue'
        static member initial = FssTypes.Initial |> bottomValue'
        static member unset = FssTypes.Unset |> bottomValue'

    /// <summary>Specifies vertial position of element.</summary>
    /// <param name="bottom">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Bottom' = Bottom.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/left
    let private leftValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Left
    let private leftValue' = positionedToString >> leftValue

    [<Erase>]
    type Left =
        static member value (left: FssTypes.IPositioned) = left |> leftValue'

        static member auto = FssTypes.Auto |> leftValue'
        static member inherit' = FssTypes.Inherit |> leftValue'
        static member initial = FssTypes.Initial |> leftValue'
        static member unset = FssTypes.Unset |> leftValue'

    /// <summary>Specifies vertical alignment.</summary>
    /// <param name="left">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Left' = Left.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/vertical-align
    let private verticalAlignValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.VerticalAlign
    let private verticalAlignValue' = verticalAlignToString >> verticalAlignValue

    [<Erase>]
    type VerticalAlign =
        static member value (alignment: FssTypes.IVerticalAlign) = alignment |> verticalAlignValue'
        static member baseline = FssTypes.Position.VerticalAlign.Baseline |> verticalAlignValue'
        static member sub = FssTypes.Position.VerticalAlign.Sub |> verticalAlignValue'
        static member super = FssTypes.Position.VerticalAlign.Super |> verticalAlignValue'
        static member textTop = FssTypes.Position.VerticalAlign.TextTop |> verticalAlignValue'
        static member textBottom = FssTypes.Position.VerticalAlign.TextBottom |> verticalAlignValue'
        static member middle = FssTypes.Position.VerticalAlign.Middle |> verticalAlignValue'
        static member top = FssTypes.Position.VerticalAlign.Top |> verticalAlignValue'
        static member bottom = FssTypes.Position.VerticalAlign.Bottom |> verticalAlignValue'

        static member inherit' = FssTypes.Inherit |> verticalAlignValue'
        static member initial = FssTypes.Initial |> verticalAlignValue'
        static member unset = FssTypes.Unset |> verticalAlignValue'

    /// <summary>Specifies vertical alignment.</summary>
    /// <param name="alignment">
    ///     can be:
    ///     - <c> VerticalAlign </c>
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let VerticalAlign' = VerticalAlign.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/float
    let private floatValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Float
    let private floatValue' = floatToString >> floatValue

    [<Erase>]
    type Float =
        static member value (float: FssTypes.IFloat) = float |> floatValue'
        static member left = FssTypes.Position.Float.Left |> floatValue'
        static member right = FssTypes.Position.Float.Right |> floatValue'
        static member inlineStart = FssTypes.Position.Float.InlineStart |> floatValue'
        static member inlineEnd = FssTypes.Position.Float.InlineEnd |> floatValue'

        static member none = FssTypes.None' |> floatValue'
        static member inherit' = FssTypes.Inherit |> floatValue'
        static member initial = FssTypes.Initial |> floatValue'
        static member unset = FssTypes.Unset |> floatValue'

    /// <summary>Specifies element float.</summary>
    /// <param name="float">
    ///     can be:
    ///     - <c> Float </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Float' = Float.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-sizing
    let private boxSizingValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BoxSizing
    let private boxSizingValue' = Utilities.Helpers.duToKebab >> boxSizingValue
    [<Erase>]
    type BoxSizing =
        static member value (boxSizing: FssTypes.Position.BoxSizing) = boxSizing |> boxSizingValue'
        static member contentBox = FssTypes.Position.BoxSizing.ContentBox |> boxSizingValue'
        static member borderBox = FssTypes.Position.BoxSizing.BorderBox |> boxSizingValue'

    /// <summary>Specifies how the total width and height of an elemenent is calculated.</summary>
    /// <param name="sizing"> How to calculate width and height How to calculate width. </param>
    /// <returns>Css property for fss.</returns>
    let BoxSizing' = BoxSizing.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/direction
    let private directionValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Direction
    let private directionValue' = directionToString >> directionValue

    [<Erase>]
    type Direction =
        static member value (direction: FssTypes.IDirection) = direction |> directionValue'
        static member rtl = FssTypes.Position.Direction.Rtl |> directionValue'
        static member ltr = FssTypes.Position.Direction.Ltr |> directionValue'
        static member inherit' = FssTypes.Inherit |> directionValue'
        static member initial = FssTypes.Initial |> directionValue'
        static member unset = FssTypes.Unset |> directionValue'

    /// <summary>Specifies element float.</summary>
    /// <param name="direction">
    ///     can be:
    ///     - <c> Direction </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Direction' = Direction.value


[<AutoOpen>]
module WritingMode =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/writing-mode
    let private writingModeToString (writingMode: FssTypes.IWritingMode) =
        match writingMode with
        | :? FssTypes.WritingMode.WritingMode as w -> Utilities.Helpers.duToKebab w
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown writing mode"

    let private writingModeValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.WritingMode
    let private writingModeValue' = writingModeToString >> writingModeValue

    [<Erase>]
    type WritingMode =
        static member value (writingMode: FssTypes.IWritingMode) = writingMode |> writingModeValue'

        static member horizontalTb = FssTypes.WritingMode.HorizontalTb |> writingModeValue'
        static member verticalRl = FssTypes.WritingMode.VerticalRl |> writingModeValue'
        static member verticalLr = FssTypes.WritingMode.VerticalLr |> writingModeValue'
        static member inherit' = FssTypes.Inherit |> writingModeValue'
        static member initial = FssTypes.Initial |> writingModeValue'
        static member unset = FssTypes.Unset |> writingModeValue'

    /// <summary>Specifies direction elements are written.</summary>
    /// <param name="writingMode">
    ///     can be:
    ///     - <c> WritingMode </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let WritingMode' = WritingMode.value


[<AutoOpen>]
module Break =
    let private breakAfterToString (breakAfter: FssTypes.IBreakAfter) =
        match breakAfter with
        | :? FssTypes.Position.BreakAfter as w -> Utilities.Helpers.duToKebab w
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown break after"

    let private breakBeforeToString (breakBefore: FssTypes.IBreakBefore) =
        match breakBefore with
        | :? FssTypes.Position.BreakBefore as w -> Utilities.Helpers.duToKebab w
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown break before"

    let private breakInsideToString (breakInside: FssTypes.IBreakInside) =
        match breakInside with
        | :? FssTypes.Position.BreakInside as w -> Utilities.Helpers.duToKebab w
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown break before"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-after
    let private breakAfterValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BreakAfter
    let private breakAfterValue' = breakAfterToString >> breakAfterValue

    [<Erase>]
    type BreakAfter =
        static member value (breakAfter: FssTypes.IBreakAfter) = breakAfter |> breakAfterValue'
        static member avoid = FssTypes.Position.BreakAfter.Avoid |> breakAfterValue'
        static member always = FssTypes.Position.BreakAfter.Always |> breakAfterValue'
        static member all = FssTypes.Position.BreakAfter.All |> breakAfterValue'
        static member avoidPage = FssTypes.Position.BreakAfter.AvoidPage |> breakAfterValue'
        static member page = FssTypes.Position.BreakAfter.Page |> breakAfterValue'
        static member left = FssTypes.Position.BreakAfter.Left |> breakAfterValue'
        static member right = FssTypes.Position.BreakAfter.Right |> breakAfterValue'
        static member recto = FssTypes.Position.BreakAfter.Recto |> breakAfterValue'
        static member verso = FssTypes.Position.BreakAfter.Verso |> breakAfterValue'
        static member avoidColumn = FssTypes.Position.BreakAfter.AvoidColumn |> breakAfterValue'
        static member column = FssTypes.Position.BreakAfter.Column |> breakAfterValue'
        static member avoidRegion = FssTypes.Position.BreakAfter.AvoidRegion |> breakAfterValue'
        static member region = FssTypes.Position.BreakAfter.Region |> breakAfterValue'

        static member auto = FssTypes.Auto |> breakAfterValue'
        static member inherit' = FssTypes.Inherit |> breakAfterValue'
        static member initial = FssTypes.Initial |> breakAfterValue'
        static member unset = FssTypes.Unset |> breakAfterValue'

    /// <summary>Specifies how elements behave after a generated box.</summary>
    /// <param name="breakAfter">
    ///     can be:
    ///     - <c> BreakAfter </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BreakAfter' = BreakAfter.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-before
    let private breakBeforeValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BreakBefore
    let private breakBeforeValue'  = breakBeforeToString >> breakBeforeValue

    [<Erase>]
    type BreakBefore =
        static member value (breakBefore: FssTypes.IBreakBefore) = breakBefore |> breakBeforeValue'
        static member avoid = FssTypes.Position.BreakBefore.Avoid |> breakBeforeValue'
        static member always = FssTypes.Position.BreakBefore.Always |> breakBeforeValue'
        static member all = FssTypes.Position.BreakBefore.All |> breakBeforeValue'
        static member avoidPage = FssTypes.Position.BreakBefore.AvoidPage |> breakBeforeValue'
        static member page = FssTypes.Position.BreakBefore.Page |> breakBeforeValue'
        static member left = FssTypes.Position.BreakBefore.Left |> breakBeforeValue'
        static member right = FssTypes.Position.BreakBefore.Right |> breakBeforeValue'
        static member recto = FssTypes.Position.BreakBefore.Recto |> breakBeforeValue'
        static member verso = FssTypes.Position.BreakBefore.Verso |> breakBeforeValue'
        static member avoidColumn = FssTypes.Position.BreakBefore.AvoidColumn |> breakBeforeValue'
        static member column = FssTypes.Position.BreakBefore.Column |> breakBeforeValue'
        static member avoidRegion = FssTypes.Position.BreakBefore.AvoidRegion |> breakBeforeValue'
        static member region = FssTypes.Position.BreakBefore.Region |> breakBeforeValue'

        static member auto = FssTypes.Auto |> breakBeforeValue'
        static member inherit' = FssTypes.Inherit |> breakBeforeValue'
        static member initial = FssTypes.Initial |> breakBeforeValue'
        static member unset = FssTypes.Unset |> breakBeforeValue'

    /// <summary>Specifies how elements behave before a generated box.</summary>
    /// <param name="breakBefore">
    ///     can be:
    ///     - <c> BreakBefore </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BreakBefore' = BreakBefore.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-inside
    let private breakInsideValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BreakInside
    let private breakInsideValue' = breakInsideToString >> breakInsideValue

    [<Erase>]
    type BreakInside =
        static member value (breakInside: FssTypes.IBreakInside) = breakInside |> breakInsideValue'
        static member avoid = FssTypes.Position.BreakInside.Avoid |> breakInsideValue'
        static member avoidPage = FssTypes.Position.BreakInside.AvoidPage |> breakInsideValue'
        static member avoidColumn = FssTypes.Position.BreakInside.AvoidColumn |> breakInsideValue'
        static member avoidRegion = FssTypes.Position.BreakInside.AvoidRegion |> breakInsideValue'

        static member auto = FssTypes.Auto |> breakInsideValue'
        static member inherit' = FssTypes.Inherit |> breakInsideValue'
        static member initial = FssTypes.Initial |> breakInsideValue'
        static member unset = FssTypes.Unset |> breakInsideValue'

    /// <summary>Specifies how elements behave inside a generated box.</summary>
    /// <param name="breakInside">
    ///     can be:
    ///     - <c> BreakInside </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BreakInside' = BreakInside.value

