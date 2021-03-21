namespace Fss
open FssTypes

// https://developer.mozilla.org/en-US/docs/Web/CSS/visibility
[<AutoOpen>]
module Visibility =
    let private visibilityValue value = PropertyValue.cssValue Property.Visibility value
    let private visibilityValue' value =
        value
        |> FssTypes.Visibility.value
        |> visibilityValue

    type Visibility =
        static member Value (visibility: IVisibility) = visibility |> visibilityValue'
        static member Visible = FssTypes.Visibility.Visible |> visibilityValue'
        static member Hidden = FssTypes.Visibility.Hidden |> visibilityValue'
        static member Collapse = FssTypes.Visibility.Collapse |> visibilityValue'

        static member Inherit = Inherit |> visibilityValue'
        static member Initial = Initial |> visibilityValue'
        static member Unset = Unset |> visibilityValue'

    /// <summary>Specifies if an element is visible.</summary>
    /// <param name="visibility">
    ///     can be:
    ///     - <c> Visibility </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Visibility' (visibility: IVisibility) = Visibility.Value(visibility)

// https://developer.mozilla.org/en-US/docs/Web/CSS/opacity
[<AutoOpen>]
module Opacity =
    type Opacity =
        static member Value value =
            PropertyValue.cssValue Property.Opacity
            <| string (Utilities.Helpers.clamp 0.0 1.0 value)

    /// <summary>Specifies the opacity of an element.</summary>
    /// <param name="opacity"> </param>
    /// <returns>Css property for fss.</returns>
    let Opacity' (opacity: float) = Opacity.Value(opacity)


[<AutoOpen>]
module PaintOrder =
    let private paintOrderToString (paintOrder: IPaintOrder) =
        match paintOrder with
        | :? PaintOrder as p -> Utilities.Helpers.duToLowercase p
        | :? Normal -> normal
        | _ -> "unknown paint order"

    let private paintOrderValue value = PropertyValue.cssValue Property.PaintOrder value
    let private paintOrderValue' value =
        value
        |> paintOrderToString
        |> paintOrderValue

    // https://developer.mozilla.org/en-US/docs/Web/CSS/paint-order
    type PaintOrder =
        static member Value(order: IPaintOrder) = order |> paintOrderValue'
        static member Value(o1: IPaintOrder, o2: IPaintOrder) =
            sprintf "%s %s"
                (paintOrderToString o1)
                (paintOrderToString o2)
            |> paintOrderValue
        static member Value(o1: IPaintOrder, o2: IPaintOrder, o3: IPaintOrder) =
            sprintf "%s %s %s"
                (paintOrderToString o1)
                (paintOrderToString o2)
                (paintOrderToString o3)
            |> paintOrderValue
        static member Stroke = FssTypes.PaintOrder.Stroke |> paintOrderValue'
        static member Markers = FssTypes.PaintOrder.Markers |> paintOrderValue'
        static member Fill = FssTypes.PaintOrder.Fill |> paintOrderValue'
        static member Normal = Normal |> paintOrderValue'

    /// <summary>Specifies in which order the fill and strokes are drawn.</summary>
    /// <param name="order">
    ///     can be:
    ///     - <c> PaintOrder </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let PaintOrder' (order: IPaintOrder) = PaintOrder.Value(order)

