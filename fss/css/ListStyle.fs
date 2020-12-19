﻿namespace Fss

module ListStyleTypeType =
    type ListStyleImage =
        | ListStyleImage of string
        interface IListStyleImage

    type ListStylePosition =
        | Inside
        | Outside
        interface IListStylePosition

    type ListStyleType =
        | Disc
        | Circle
        | Square
        | Decimal
        | CjkDecimal
        | DecimalLeadingZero
        | LowerRoman
        | UpperRoman
        | LowerGreek
        | LowerAlpha
        | LowerLatin
        | UpperAlpha
        | UpperLatin
        | ArabicIndic
        | Armenian
        | Bengali
        | Cambodian
        | CjkEarthlyBranch
        | CjkHeavenlyStem
        | CjkIdeographic
        | Devanagari
        | EthiopicNumeric
        | Georgian
        | Gujarati
        | Gurmukhi
        | Hebrew
        | Hiragana
        | HiraganaIroha
        | JapaneseFormal
        | JapaneseInformal
        | Kannada
        | Katakana
        | KatakanaIroha
        | Khmer
        | KoreanHangulFormal
        | KoreanHanjaFormal
        | KoreanHanjaInformal
        | Lao
        | LowerArmenian
        | Malayalam
        | Mongolian
        | Myanmar
        | Oriya
        | Persian
        | SimpChineseFormal
        | SimpChineseInformal
        | Tamil
        | Telugu
        | Thai
        | Tibetan
        | TradChineseFormal
        | TradChineseInformal
        | UpperArmenian
        | DisclosureOpen
        | DisclosureClosed
        interface IListStyleType

    let styleTypeToString (styleType: IListStyleType) =
        let stringifyStyle =
            function
                | Disc -> "disc"
                | Circle -> "circle"
                | Square -> "square"
                | Decimal -> "decimal"
                | CjkDecimal -> "cjk-decimal"
                | DecimalLeadingZero -> "decimal-leading-zero"
                | LowerRoman -> "lower-roman"
                | UpperRoman -> "upper-roman"
                | LowerGreek -> "lower-greek"
                | LowerAlpha -> "lower-alpha"
                | LowerLatin -> "lower-latin"
                | UpperAlpha -> "upper-alpha"
                | UpperLatin -> "upper-latin"
                | ArabicIndic -> "arabic-indic"
                | Armenian -> "armenian"
                | Bengali -> "bengali"
                | Cambodian -> "cambodian"
                | CjkEarthlyBranch -> "cjk-earthly-branch"
                | CjkHeavenlyStem -> "cjk-heavenly-stem"
                | CjkIdeographic -> "cjk-ideographic"
                | Devanagari -> "devanagari"
                | EthiopicNumeric -> "ethiopic-numeric"
                | Georgian -> "georgian"
                | Gujarati -> "gujarati"
                | Gurmukhi -> "gurmukhi"
                | Hebrew -> "hebrew"
                | Hiragana -> "hiragana"
                | HiraganaIroha -> "hiragana-iroha"
                | JapaneseFormal -> "japanese-formal"
                | JapaneseInformal -> "japanese-informal"
                | Kannada -> "kannada"
                | Katakana -> "katakana"
                | KatakanaIroha -> "katakana-iroha"
                | Khmer -> "khmer"
                | KoreanHangulFormal -> "korean-hangul-formal"
                | KoreanHanjaFormal -> "korean-hanja-formal"
                | KoreanHanjaInformal -> "korean-hanja-informal"
                | Lao -> "lao"
                | LowerArmenian -> "lower-armenian"
                | Malayalam -> "malayalam"
                | Mongolian -> "mongolian"
                | Myanmar -> "myanmar"
                | Oriya -> "oriya"
                | Persian -> "persian"
                | SimpChineseFormal -> "simp-chinese-formal"
                | SimpChineseInformal -> "simp-chinese-informal"
                | Tamil -> "tamil"
                | Telugu -> "telugu"
                | Thai -> "thai"
                | Tibetan -> "tibetan"
                | TradChineseFormal -> "trad-chinese-formal"
                | TradChineseInformal -> "trad-chinese-informal"
                | UpperArmenian -> "upper-armenian"
                | DisclosureOpen -> "disclosure-open"
                | DisclosureClosed -> "disclosure-closed"

        match styleType with
        | :? ListStyleType as l -> stringifyStyle l
        | :? CounterStyle as c -> counterValue c
        | :? CssString as s -> GlobalValue.string s |> sprintf "'%s'"
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown list style type"

[<AutoOpen>]
module ListStyle =
    open ListStyleTypeType

    let private listStyleImageToString (image: IListStyleImage) =
        let stringifyImage =
            function
                | ListStyleImage u -> sprintf "url('%s')" u

        match image with
        | :? ListStyleImage as l -> stringifyImage l
        | :? Global as g -> GlobalValue.global' g
        | :? None -> GlobalValue.none
        | _ -> "unknown list style image"

    let private stylePositionToString (stylePosition: IListStylePosition) =
        let stringifyListStyle =
            function
                | Inside -> "inside"
                | Outside -> "outside"

        match stylePosition with
        | :? ListStylePosition as l -> stringifyListStyle l
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown list style position"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-image
    let private listStyleImageValue (value: string) = PropertyValue.cssValue Property.ListStyleImage value
    let private listStyleImageValue' value =
        value
        |> listStyleImageToString
        |> listStyleImageValue

    type ListStyleImage =
        static member Value (styleImage: IListStyleImage) = styleImage |> listStyleImageValue'
        static member Url (url: string) = ListStyleTypeType.ListStyleImage url |> listStyleImageValue'

        static member None = None |> listStyleImageValue'
        static member Inherit = Inherit |> listStyleImageValue'
        static member Initial = Initial |> listStyleImageValue'
        static member Unset = Unset |> listStyleImageValue'

    let ListStyleImage' (image: IListStyleImage) = ListStyleImage.Value(image)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-position
    let private listStylePositionProperty (value: string) = PropertyValue.cssValue Property.ListStylePosition value
    let private listStylePositionProperty' value =
        value
        |> stylePositionToString
        |> listStylePositionProperty

    type ListStylePosition =
        static member Value (stylePosition: IListStylePosition) = stylePosition |> listStylePositionProperty'
        static member Inside = Inside |> listStylePositionProperty'
        static member Outside = Outside |> listStylePositionProperty'

        static member Inherit = Inherit |> listStylePositionProperty'
        static member Initial = Initial |> listStylePositionProperty'
        static member Unset = Unset |> listStylePositionProperty'

    let ListStylePosition' (position: IListStylePosition) = ListStylePosition.Value(position)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-type
    let private listStyleTypeProperty (value: string) = PropertyValue.cssValue Property.ListStyleType value
    let private listStyleTypeProperty' value =
        value
        |> styleTypeToString
        |> listStyleTypeProperty
    type ListStyleType =
        static member Value (styleType: IListStyleType) = styleType |> listStyleTypeProperty'
        static member Value(counter: CounterStyle) = counterValue counter |> listStyleTypeProperty
        static member Disc = Disc |> listStyleTypeProperty'
        static member Circle = Circle |> listStyleTypeProperty'
        static member Square = Square |> listStyleTypeProperty'
        static member Decimal = Decimal |> listStyleTypeProperty'
        static member CjkDecimal = CjkDecimal |> listStyleTypeProperty'
        static member DecimalLeadingZero = DecimalLeadingZero |> listStyleTypeProperty'
        static member LowerRoman = LowerRoman |> listStyleTypeProperty'
        static member UpperRoman = UpperRoman |> listStyleTypeProperty'
        static member LowerGreek = LowerGreek |> listStyleTypeProperty'
        static member LowerAlpha = LowerAlpha |> listStyleTypeProperty'
        static member LowerLatin = LowerLatin |> listStyleTypeProperty'
        static member UpperAlpha = UpperAlpha |> listStyleTypeProperty'
        static member UpperLatin = UpperLatin |> listStyleTypeProperty'
        static member ArabicIndic = ArabicIndic |> listStyleTypeProperty'
        static member Armenian = Armenian |> listStyleTypeProperty'
        static member Bengali = Bengali |> listStyleTypeProperty'
        static member Cambodian = Cambodian |> listStyleTypeProperty'
        static member CjkEarthlyBranch = CjkEarthlyBranch |> listStyleTypeProperty'
        static member CjkHeavenlyStem = CjkHeavenlyStem |> listStyleTypeProperty'
        static member CjkIdeographic = CjkIdeographic |> listStyleTypeProperty'
        static member Devanagari = Devanagari |> listStyleTypeProperty'
        static member EthiopicNumeric = EthiopicNumeric |> listStyleTypeProperty'
        static member Georgian = Georgian |> listStyleTypeProperty'
        static member Gujarati = Gujarati |> listStyleTypeProperty'
        static member Gurmukhi = Gurmukhi |> listStyleTypeProperty'
        static member Hebrew = Hebrew |> listStyleTypeProperty'
        static member Hiragana = Hiragana |> listStyleTypeProperty'
        static member HiraganaIroha = HiraganaIroha |> listStyleTypeProperty'
        static member JapaneseFormal = JapaneseFormal |> listStyleTypeProperty'
        static member JapaneseInformal = JapaneseInformal |> listStyleTypeProperty'
        static member Kannada = Kannada |> listStyleTypeProperty'
        static member Katakana = Katakana |> listStyleTypeProperty'
        static member KatakanaIroha = KatakanaIroha |> listStyleTypeProperty'
        static member Khmer = Khmer |> listStyleTypeProperty'
        static member KoreanHangulFormal = KoreanHangulFormal |> listStyleTypeProperty'
        static member KoreanHanjaFormal = KoreanHanjaFormal |> listStyleTypeProperty'
        static member KoreanHanjaInformal = KoreanHanjaInformal |> listStyleTypeProperty'
        static member Lao = Lao |> listStyleTypeProperty'
        static member LowerArmenian = LowerArmenian |> listStyleTypeProperty'
        static member Malayalam = Malayalam |> listStyleTypeProperty'
        static member Mongolian = Mongolian |> listStyleTypeProperty'
        static member Myanmar = Myanmar |> listStyleTypeProperty'
        static member Oriya = Oriya |> listStyleTypeProperty'
        static member Persian = Persian |> listStyleTypeProperty'
        static member SimpChineseFormal = SimpChineseFormal |> listStyleTypeProperty'
        static member SimpChineeInformal = SimpChineseInformal |> listStyleTypeProperty'
        static member Tamil = Tamil |> listStyleTypeProperty'
        static member Telugu = Telugu |> listStyleTypeProperty'
        static member Thai = Thai |> listStyleTypeProperty'
        static member Tibetan = Tibetan |> listStyleTypeProperty'
        static member TradChineseFormal = TradChineseFormal |> listStyleTypeProperty'
        static member TradChineseInformal = TradChineseInformal |> listStyleTypeProperty'
        static member UpperArmenian = UpperArmenian |> listStyleTypeProperty'
        static member DisclosureOpen = DisclosureOpen |> listStyleTypeProperty'
        static member DisclosureClosed = DisclosureClosed |> listStyleTypeProperty'

        static member Inherit = Inherit |> listStyleTypeProperty'
        static member Initial = Initial |> listStyleTypeProperty'
        static member Unset = Unset |> listStyleTypeProperty'

    let ListStyleType' (style: IListStyleType) = ListStyleType.Value(style)
