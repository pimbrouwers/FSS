namespace Fss

open FssTypes
open FssTypes

[<AutoOpen>]
module Font =
    let private fontSizeToString (fontSize: IFontSize) =
        match fontSize with
        | :? FontSize as f -> Utilities.Helpers.duToKebab f
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> global' g
        | _ -> "Unknown font size"

    let private familyToString (fontFamily: IFontFamily) =
        let stringifyFontName (FssTypes.FontName n) = n
        let stringifyFamily fontFamily =
            match fontFamily with
                | Custom c -> sprintf "'%s'" c
                | FssTypes.FontFamily.FontName n -> stringifyFontName n
                | _ -> Utilities.Helpers.duToKebab fontFamily

        match fontFamily with
            | :? FontFamily as f -> stringifyFamily f
            | :? Global as g -> global' g
            | _ -> "Unknown font family"

    let private featureSettingToString (featureSetting: IFontFeatureSetting) =
        let stringifyFeature =
            function
                | Liga switch    -> sprintf "\"liga\" %A" switch
                | Dlig switch    -> sprintf "\"dlig\" %A" switch
                | Onum switch    -> sprintf "\"onum\" %A" switch
                | Lnum switch    -> sprintf "\"lnum\" %A" switch
                | Tnum switch    -> sprintf "\"tnum\" %A" switch
                | Zero switch    -> sprintf "\"zero\" %A" switch
                | Frac switch    -> sprintf "\"frac\" %A" switch
                | Sups switch    -> sprintf "\"sups\" %A" switch
                | Subs switch    -> sprintf "\"subs\" %A" switch
                | Smcp switch    -> sprintf "\"smcp\" %A" switch
                | C2sc switch    -> sprintf "\"c2sc\" %A" switch
                | Case switch    -> sprintf "\"case\" %A" switch
                | Hlig switch    -> sprintf "\"hlig\" %A" switch
                | Calt switch    -> sprintf "\"calt\" %A" switch
                | Swsh switch    -> sprintf "\"swsh\" %A" switch
                | Hist switch    -> sprintf "\"hist\" %A" switch
                | Ss (n, switch) -> sprintf "\"ss%2i\" %A" n switch
                | Kern switch    -> sprintf "\"kern\" %A" switch
                | Locl switch    -> sprintf "\"locl\" %A" switch
                | Rlig switch    -> sprintf "\"rlig\" %A" switch
                | Medi switch    -> sprintf "\"medi\" %A" switch
                | Init switch    -> sprintf "\"init\" %A" switch
                | Isol switch    -> sprintf "\"isol\" %A" switch
                | Fina switch    -> sprintf "\"fina\" %A" switch
                | Mark switch    -> sprintf "\"mark\" %A" switch
                | Mkmk switch    -> sprintf "\"mkmk\" %A" switch

        match featureSetting with
        | :? FontFeatureSetting as f -> stringifyFeature f
        | :? Global as g -> global' g
        | _ -> "unknown font feature setting"

    let private variantNumericToString (variant: IFontVariantNumeric) =
        match variant with
        | :? FontVariantNumeric as f -> Utilities.Helpers.duToKebab f
        | :? Global as g -> global' g
        | :? Normal -> normal
        | _ -> "Unknown font variant numeric"

    let private fontVariantCapsToString (variant: IFontVariantCaps) =
        match variant with
        | :? FontVariantCaps as f -> Utilities.Helpers.duToKebab f
        | :? Global as g -> global' g
        | :? Normal -> normal
        | _ -> "Unknown font variant caps"

    let private variantEastAsianToString (variant: IFontVariantEastAsian) =
        match variant with
        | :? FontVariantEastAsian as f -> Utilities.Helpers.duToKebab f
        | :? Global as g -> global' g
        | :? Normal -> normal
        | _ -> "Unknown font variant east asian"

    let private variantLigatureToString (variant: IFontVariantLigature) =
        match variant with
        | :? FontVariantLigature as f -> Utilities.Helpers.duToKebab f
        | :? Global as g -> global' g
        | :? Normal -> normal
        | :? None' -> none
        | _ -> "Unknown font variant ligature"

    let private lineHeightToString (lineHeight: ILineHeight) =
        match lineHeight with
        | :? CssFloat as f -> cssFloatToString f
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> global' g
        | :? Normal -> normal
        | _ -> "Unknown line height"

    let private lineBreakToString (linebreak: ILineBreak) =
        match linebreak with
        | :? LineBreak as l -> Utilities.Helpers.duToLowercase l
        | :? Auto -> auto
        | :? Normal -> normal
        | :? Global as g -> global' g
        | _ -> "Unknown line break"

    let private letterSpacingToString (letterSpacing: ILetterSpacing) =
        match letterSpacing with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Global as g -> global' g
        | :? Normal -> normal
        | _ -> "Unknown letter spacing"

    let private fontKerningTostring (fontKerning: IFontKerning) =
        match fontKerning with
        | :? Normal -> normal
        | :? Auto -> auto
        | :? None' -> none
        | _ -> "Unknown font kerning"

    let private fontLanguageOverrideToString (fontLanguageOverride: IFontLanguageOverride) =
        match fontLanguageOverride with
        | :? Normal -> normal
        | :? Global as g -> global' g
        | _ -> "Unknown font language override"

    let private fontSynthesisToString (synthesis: IFontSynthesis) =
        match synthesis with
        | :? FontSynthesis as f -> Utilities.Helpers.duToSpaced f
        | :? None' -> none
        | _ -> "Unknown font synthesis"

    let private fontVariantPositionToString (variantPosition: IFontVariantPosition) =
        match variantPosition with
        | :? FontVariantPosition as f -> Utilities.Helpers.duToLowercase f
        | :? Global as g -> global' g
        | :? Normal -> normal
        | _ -> "Unknown font variant position"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-size
    let private sizeCssValue value = PropertyValue.cssValue Property.FontSize value
    let private sizeCssValue' value = value |> fontSizeToString |> sizeCssValue
    type FontSize =
        static member Value (value: IFontSize) = value |> sizeCssValue'
        static member XxSmall = XxSmall |> sizeCssValue'
        static member XSmall = XSmall |> sizeCssValue'
        static member Small = Small |> sizeCssValue'
        static member Medium = FssTypes.FontSize.Medium |> sizeCssValue'
        static member Large = Large |> sizeCssValue'
        static member XLarge = XLarge |> sizeCssValue'
        static member XxLarge = XxLarge |> sizeCssValue'
        static member XxxLarge = XxxLarge |> sizeCssValue'
        static member Smaller = Smaller |> sizeCssValue'
        static member Larger = Larger |> sizeCssValue'

        static member Inherit = Inherit |> sizeCssValue'
        static member Initial = Initial |> sizeCssValue'
        static member Unset = Unset |> sizeCssValue'

    /// <summary>Sets size of font. </summary>
    /// <param name="size">
    ///     can be:
    ///     - <c> FontSize </c>
    ///     - <c> Size </c>
    ///     - <c> Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontSize' (size: IFontSize) = FontSize.Value(size)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-style
    let private styleCssValue value = PropertyValue.cssValue Property.FontStyle value
    let private styleCssValue' value = value |> Font.fontStyleToString |> styleCssValue
    type FontStyle =
        static member Value (fontStyle: IFontStyle) = fontStyle |> styleCssValue'
        static member Oblique (angle: Units.Angle.Angle) = Oblique angle |> styleCssValue'
        static member Italic = Italic |> styleCssValue'

        static member Normal = Normal |> styleCssValue'
        static member Inherit = Inherit |> styleCssValue'
        static member Initial = Initial |> styleCssValue'
        static member Unset = Unset |> styleCssValue'

    /// <summary>Specifies which style to use on a font. </summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> FontStyle </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontStyle' (style: IFontStyle) = FontStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-stretch
    let private stretchCssValue value = PropertyValue.cssValue Property.FontStretch value
    let private stretchCssValue' value = value |> Font.fontStretchToString |> stretchCssValue
    type FontStretch =
        static member Value (fontStretch: IFontStretch) = fontStretch |> stretchCssValue'
        static member Value (percent: Units.Percent.Percent) =
            Units.Percent.value percent
            |> stretchCssValue
        static member SemiCondensed = SemiCondensed |> stretchCssValue'
        static member Condensed = Condensed |> stretchCssValue'
        static member ExtraCondensed = ExtraCondensed |> stretchCssValue'
        static member UltraCondensed = UltraCondensed |> stretchCssValue'
        static member SemiExpanded = SemiExpanded |> stretchCssValue'
        static member Expanded = Expanded |> stretchCssValue'
        static member ExtraExpanded = ExtraExpanded |> stretchCssValue'
        static member UltraExpanded = UltraExpanded |> stretchCssValue'
        static member Normal = Normal |> stretchCssValue'
        static member Inherit = Inherit |> stretchCssValue'
        static member Initial = Initial |> stretchCssValue'
        static member Unset = Unset |> stretchCssValue'

    /// <summary>Specifies width of text characters to be wider or narrower default width. </summary>
    /// <param name="stretch">
    ///     can be:
    ///     - <c> FontStretch </c>
    ///     - <c> Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontStretch' (stretch: IFontStretch) = FontStretch.Value(stretch)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight
    let private weightCssValue value = PropertyValue.cssValue Property.FontWeight value
    let private weightCssValue' value = value |> Font.fontWeightToString |> weightCssValue
    type FontWeight =
        static member Value (fontWeight: IFontWeight) = fontWeight |> weightCssValue'
        static member Bold = Bold |> weightCssValue'
        static member Lighter = Lighter |> weightCssValue'
        static member Bolder = Bolder |> weightCssValue'

        static member Normal = Normal |> weightCssValue'
        static member Inherit = Inherit |> weightCssValue'
        static member Initial = Initial |> weightCssValue'
        static member Unset = Unset |> weightCssValue'

    /// <summary>Specifies weight(boldness) of font. </summary>
    /// <param name="weight">
    ///     can be:
    ///     - <c> FontWeight </c>
    ///     - <c> CssInt </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontWeight' (weight: IFontWeight) = FontWeight.Value(weight)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/line-height
    let private heightCssValue value = PropertyValue.cssValue Property.LineHeight value
    let private heightCssValue' value =
        value
        |> lineHeightToString
        |> heightCssValue
    type LineHeight =
        static member Value (height: ILineHeight) = height |> heightCssValue'

        static member Normal = Normal |> heightCssValue'
        static member Inherit = Inherit |> heightCssValue'
        static member Initial = Initial |>  heightCssValue'
        static member Unset = Unset |>  heightCssValue'

    /// <summary>Specifies the amount of space above and below inline elements. </summary>
    /// <param name="height">
    ///     can be:
    ///     - <c> CssFloat </c>
    ///     - <c> Size </c>
    ///     - <c> Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let LineHeight' (height: ILineHeight) = LineHeight.Value(height)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/line-break
    let private breakCssValue value = PropertyValue.cssValue Property.LineBreak value
    let private breakCssValue' value =
        value
        |> lineBreakToString
        |> breakCssValue
    type LineBreak =
        static member Value (break': ILineBreak) = break' |> breakCssValue'
        static member Loose = Loose |> breakCssValue'
        static member Strict = Strict |> breakCssValue'
        static member Anywhere = FssTypes.LineBreak.Anywhere |> breakCssValue'

        static member Normal = Normal |> breakCssValue'
        static member Auto = Auto |> breakCssValue'
        static member Inherit = Inherit |> breakCssValue'
        static member Initial = Initial |>  breakCssValue'
        static member Unset = Unset |>  breakCssValue'

    /// <summary>Specifies how some asian languages wrap text on newlines. </summary>
    /// <param name="break'">
    ///     can be:
    ///     - <c> LineBreak </c>
    ///     - <c> Auto </c>
    ///     - <c> Normal </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let LineBreak' (break': ILineBreak) = LineBreak.Value(break')

    // https://developer.mozilla.org/en-US/docs/Web/CSS/letter-spacing
    let private spacingCssValue value = PropertyValue.cssValue Property.LetterSpacing value
    let private spacingCssValue' value =
        value
        |> letterSpacingToString
        |> spacingCssValue
    type LetterSpacing =
        static member Value (spacing: ILetterSpacing) = spacing |> spacingCssValue'

        static member Normal = Normal |> spacingCssValue'
        static member Inherit = Inherit |> spacingCssValue'
        static member Initial = Initial |>  spacingCssValue'
        static member Unset = Unset |>  spacingCssValue'

    /// <summary>Sets horizontal spacing between text characters. </summary>
    /// <param name="spacing">
    ///     can be:
    ///     - <c> Size </c>
    ///     - <c> Normal </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let LetterSpacing' (spacing: ILetterSpacing) = LetterSpacing.Value(spacing)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/font-display
    let private displayCssValue value = PropertyValue.cssValue Property.FontDisplay value
    let private displayCssValue' value =
        value
        |> Font.fontDisplayToString
        |> PropertyValue.cssValue Property.FontDisplay
    type FontDisplay =
        static member Value (fontDisplay: IFontDisplay) = fontDisplay |> displayCssValue'
        static member Block = FssTypes.FontDisplay.Block |> displayCssValue'
        static member Swap = Swap |> displayCssValue'
        static member Fallback = Fallback |> displayCssValue'
        static member Optional = Optional |> displayCssValue'

        static member Auto = Auto |> displayCssValue'

    /// <summary>Specifies how a font is loaded and displayed.</summary>
    /// <param name="display">
    ///     can be:
    ///     - <c> FontDisplay </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontDisplay' (display: IFontDisplay) = FontDisplay.Value(display)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-family
    let private familyCssValue value = PropertyValue.cssValue Property.FontFamily value
    let private familyCssValue' value = value |> familyToString |> familyCssValue

    type FontFamily =
        static member Value (fontFamily: IFontFamily) = fontFamily |> familyCssValue'
        static member Values (families: IFontFamily list) =
            families
            |> Utilities.Helpers.combineComma familyToString
            |> familyCssValue
        static member Font (font: FontName) = font |> FontFamily.FontName |> familyCssValue'
        static member Custom (font: string) = familyCssValue font
        static member Serif = Serif |> familyCssValue'
        static member SansSerif = SansSerif |> familyCssValue'
        static member Monospace = Monospace |> familyCssValue'
        static member Cursive = Cursive |> familyCssValue'

        static member Inherit = Inherit |> familyCssValue'
        static member Initial = Initial |> familyCssValue'
        static member Unset = Unset |> familyCssValue'

    /// <summary>Specify which font to use on the.</summary>
    /// <param name="fontFamily">
    ///     can be:
    ///     - <c> FontFamily </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontFamily' (fontFamily: IFontFamily) = FontFamily.Value(fontFamily)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-feature-settings
    let private featureSettingCssValue value = PropertyValue.cssValue Property.FontFeatureSettings value
    let private featureSettingCssValue' value = value |> featureSettingToString |> featureSettingCssValue

    type FontFeatureSetting =
        static member Value (featureSetting: IFontFeatureSetting) = featureSetting |> featureSettingCssValue'
        static member Liga (switch: SettingSwitch) = Liga switch |> featureSettingCssValue'
        static member Dlig (switch: SettingSwitch) = Dlig switch |> featureSettingCssValue'
        static member Onum (switch: SettingSwitch) = Onum switch |> featureSettingCssValue'
        static member Lnum (switch: SettingSwitch) = Lnum switch |> featureSettingCssValue'
        static member Tnum (switch: SettingSwitch) = Tnum switch |> featureSettingCssValue'
        static member Zero (switch: SettingSwitch) = Zero switch |> featureSettingCssValue'
        static member Frac (switch: SettingSwitch) = Frac switch |> featureSettingCssValue'
        static member Sups (switch: SettingSwitch) = Sups switch |> featureSettingCssValue'
        static member Subs (switch: SettingSwitch) = Subs switch |> featureSettingCssValue'
        static member Smcp (switch: SettingSwitch) = Smcp switch |> featureSettingCssValue'
        static member C2sc (switch: SettingSwitch) = C2sc switch |> featureSettingCssValue'
        static member Case (switch: SettingSwitch) = Case switch |> featureSettingCssValue'
        static member Hlig (switch: SettingSwitch) = Hlig switch |> featureSettingCssValue'
        static member Calt (switch: SettingSwitch) = Calt switch |> featureSettingCssValue'
        static member Swsh (switch: SettingSwitch) = Swsh switch |> featureSettingCssValue'
        static member Hist (switch: SettingSwitch) = Hist switch |> featureSettingCssValue'
        static member Ss  (n:int, switch: SettingSwitch) = Ss (n, switch) |> featureSettingCssValue'
        static member Kern (switch: SettingSwitch) = Kern switch |> featureSettingCssValue'
        static member Locl (switch: SettingSwitch) = Locl switch |> featureSettingCssValue'
        static member Rlig (switch: SettingSwitch) = Rlig switch |> featureSettingCssValue'
        static member Medi (switch: SettingSwitch) = Medi switch |> featureSettingCssValue'
        static member Init (switch: SettingSwitch) = Init switch |> featureSettingCssValue'
        static member Isol (switch: SettingSwitch) = Isol switch |> featureSettingCssValue'
        static member Fina (switch: SettingSwitch) = Fina switch |> featureSettingCssValue'
        static member Mark (switch: SettingSwitch) = Mark switch |> featureSettingCssValue'
        static member Mkmk (switch: SettingSwitch) = Mkmk switch |> featureSettingCssValue'

        static member Inherit = Inherit |> featureSettingCssValue'
        static member Initial = Initial |> featureSettingCssValue'
        static member Unset = Unset |> featureSettingCssValue'

    /// <summary>Specify more advanced typographic settings.</summary>
    /// <param name="featureSetting">
    ///     can be:
    ///     - <c> FontFeatureSetting </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontFeatureSetting' (featureSetting: IFontFeatureSetting) = FontFeatureSetting.Value(featureSetting)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-numeric
    let private variantNumericCssValue value = PropertyValue.cssValue Property.FontVariantNumeric value
    let private variantNumericCssValue' value = value |> variantNumericToString |> variantNumericCssValue

    type FontVariantNumeric =
        static member Value (variantNumeric: IFontVariantNumeric) = variantNumeric |>  variantNumericCssValue'
        static member Ordinal = Ordinal |> variantNumericCssValue'
        static member SlashedZero = SlashedZero |> variantNumericCssValue'
        static member LiningNums = LiningNums |> variantNumericCssValue'
        static member OldstyleNums = OldstyleNums |> variantNumericCssValue'
        static member ProportionalNums = ProportionalNums |> variantNumericCssValue'
        static member TabularNums = TabularNums |> variantNumericCssValue'
        static member DiagonalFractions = DiagonalFractions |> variantNumericCssValue'
        static member StackedFractions = StackedFractions |> variantNumericCssValue'

        static member Normal = Normal |> variantNumericCssValue'
        static member Inherit = Inherit |> variantNumericCssValue'
        static member Initial = Initial |> variantNumericCssValue'
        static member Unset = Unset |> variantNumericCssValue'

    /// <summary>Specifies numeric glyphs.</summary>
    /// <param name="variant">
    ///     can be:
    ///     - <c> FontFeatureSetting </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontVariantNumeric' (variant: IFontVariantNumeric) = FontVariantNumeric.Value(variant)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-caps
    let private variantCapsCssValue value = PropertyValue.cssValue Property.FontVariantCaps value
    let private variantCapsCssValue' value = value |> fontVariantCapsToString |> variantCapsCssValue
    type FontVariantCaps =
        static member Value (variantCaps: IFontVariantCaps) = variantCaps |> variantCapsCssValue'
        static member SmallCaps = SmallCaps |> variantCapsCssValue'
        static member AllSmallCaps = AllSmallCaps |> variantCapsCssValue'
        static member PetiteCaps = PetiteCaps |> variantCapsCssValue'
        static member AllPetiteCaps = AllPetiteCaps |> variantCapsCssValue'
        static member Unicase = Unicase |> variantCapsCssValue'
        static member TitlingCaps = TitlingCaps |> variantCapsCssValue'

        static member Normal = Normal |> variantCapsCssValue'
        static member Inherit = Inherit |> variantCapsCssValue'
        static member Initial = Initial |> variantCapsCssValue'
        static member Unset = Unset |> variantCapsCssValue'

    /// <summary>Specify alternate glyphs for capital letters.</summary>
    /// <param name="variant">
    ///     can be:
    ///     - <c> FontVariantCaps </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontVariantCaps' (variant: IFontVariantCaps) = FontVariantCaps.Value(variant)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
    let private variantEastAsianCssValue value = PropertyValue.cssValue Property.FontVariantEastAsian value
    let private variantEastAsianCssValue' value = value |> variantEastAsianToString |> variantEastAsianCssValue
    type FontVariantEastAsian =
        static member Value (variant: IFontVariantEastAsian) = variant |> variantEastAsianCssValue'
        static member Ruby = Ruby |> variantEastAsianCssValue'
        static member Jis78 = Jis78 |> variantEastAsianCssValue'
        static member Jis83 = Jis83 |> variantEastAsianCssValue'
        static member Jis90 = Jis90 |> variantEastAsianCssValue'
        static member Jis04 = Jis04 |> variantEastAsianCssValue'
        static member Simplified = Simplified |> variantEastAsianCssValue'
        static member Traditional = Traditional |> variantEastAsianCssValue'
        static member FullWidth = FssTypes.FontVariantEastAsian.FullWidth |> variantEastAsianCssValue'
        static member ProportionalWidth = ProportionalWidth |> variantEastAsianCssValue'

        static member Normal = Normal |> variantEastAsianCssValue'
        static member Inherit = Inherit |> variantEastAsianCssValue'
        static member Initial = Initial |> variantEastAsianCssValue'
        static member Unset = Unset |> variantEastAsianCssValue'

    /// <summary>Specifies alternate glyphs for East Asian languages.</summary>
    /// <param name="variant">
    ///     can be:
    ///     - <c> FontVariantEastAsian </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontVariantEastAsian' (variant: IFontVariantEastAsian) = FontVariantEastAsian.Value(variant)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
    let private variantLigatureCssValue value = PropertyValue.cssValue Property.FontVariantLigatures value
    let private variantLigatureCssValue' value = value |> variantLigatureToString |> variantLigatureCssValue
    type FontVariantLigatures =
        static member Value (variant: IFontVariantLigature) = variant |> variantLigatureCssValue'
        static member CommonLigatures = CommonLigatures |> variantLigatureCssValue'
        static member NoCommonLigatures = NoCommonLigatures |> variantLigatureCssValue'
        static member DiscretionaryLigatures = DiscretionaryLigatures |> variantLigatureCssValue'
        static member NoDiscretionaryLigatures = NoDiscretionaryLigatures |> variantLigatureCssValue'
        static member HistoricalLigatures = HistoricalLigatures |> variantLigatureCssValue'
        static member NoHistoricalLigatures = NoHistoricalLigatures |> variantLigatureCssValue'
        static member Contextual = Contextual |> variantLigatureCssValue'
        static member NoContextual = NoContextual |> variantLigatureCssValue'

        static member Normal = Normal |> variantLigatureCssValue'
        static member None = None' |> variantLigatureCssValue'
        static member Inherit = Inherit |> variantLigatureCssValue'
        static member Initial = Initial |> variantLigatureCssValue'
        static member Unset = Unset |> variantLigatureCssValue'

    /// <summary>Specifies which ligatures are used.</summary>
    /// <param name="ligature">
    ///     can be:
    ///     - <c> FontVariantLigature </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontVariantLigatures' (ligature: IFontVariantLigature) = FontVariantLigatures.Value(ligature)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-kerning
    let private kerningValue value = PropertyValue.cssValue Property.FontKerning value
    let private kerningValue' value = value |> fontKerningTostring |> kerningValue

    type FontKerning =
        static member Value (fontKerning: IFontKerning) = fontKerning |> kerningValue'
        static member Auto = Auto |> kerningValue'
        static member Normal = Normal |> kerningValue'
        static member None = None' |> kerningValue'

    /// <summary>Specifies use of font-kerning.</summary>
    /// <param name="fontKerning">
    ///     can be:
    ///     - <c> Auto </c>
    ///     - <c> Normal </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontKerning' (fontKerning: IFontKerning) = FontKerning.Value(fontKerning)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-language-override
    let private fontLanguageOverrideValue value = PropertyValue.cssValue Property.FontLanguageOverride value
    let private fontLanguageOverrideValue' value = value |> fontLanguageOverrideToString |> fontLanguageOverrideValue

    type FontLanguageOverride =
        static member Value (languageOverride: IFontLanguageOverride) = languageOverride |> fontLanguageOverrideValue'
        static member Value (languageOverride: string) = $"\"{languageOverride}\"" |> fontLanguageOverrideValue
        static member Normal = Normal |> fontLanguageOverrideValue'
        static member Inherit = Inherit |> fontLanguageOverrideValue'
        static member Initial = Initial |> fontLanguageOverrideValue'
        static member Unset = Unset |> fontLanguageOverrideValue'

    /// <summary>Specifies language specific glyphs.</summary>
    /// <param name="languageOverride">
    ///     can be:
    ///     - <c> Normal </c>
    ///     - <c> Initial </c>
    ///     - <c> Inherit </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontLanguageOverride' (languageOverride: IFontLanguageOverride) = FontLanguageOverride.Value(languageOverride)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-synthesis
    let private fontSynthesisValue value = PropertyValue.cssValue Property.FontSynthesis value
    let private fontSynthesisValue' value = value |> fontSynthesisToString |> fontSynthesisValue

    type FontSynthesis =
        static member Value (synthesis: IFontSynthesis) = synthesis |> fontSynthesisValue'
        static member Weight = Weight |> fontSynthesisValue'
        static member Style = Style |> fontSynthesisValue'
        static member WeightStyle = WeightStyle |> fontSynthesisValue'
        static member None = None' |> fontSynthesisValue'

    /// <summary>Specifies which missing typefaces can be synthesized by the browser.</summary>
    /// <param name="synthesis">
    ///     can be:
    ///     - <c> FontSynthesis </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontSynthesis' (synthesis: IFontSynthesis) = FontSynthesis.Value(synthesis)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-position
    let private fontVariantPositionValue value = PropertyValue.cssValue Property.FontVariantPosition value
    let private fontVariantPositionValue' value = value |> fontVariantPositionToString |> fontVariantPositionValue

    type FontVariantPosition =
        static member Value (variantPosition: IFontVariantPosition) = variantPosition |> fontVariantPositionValue'
        static member Sub = FssTypes.FontVariantPosition.Sub |> fontVariantPositionValue'
        static member Super = FssTypes.FontVariantPosition.Super |> fontVariantPositionValue'
        static member Normal = Normal |> fontVariantPositionValue'
        static member Inherit = Inherit |> fontVariantPositionValue'
        static member Initial = Initial |> fontVariantPositionValue'
        static member Unset = Unset |> fontVariantPositionValue'

    /// <summary>Specifies which missing typefaces can be synthesized by the browser.</summary>
    /// <param name="variantPosition">
    ///     can be:
    ///     - <c> FontVariantPosition </c>
    ///     - <c> Normal </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontVariantPosition' (variantPosition: IFontVariantPosition) = FontVariantPosition.Value(variantPosition)












