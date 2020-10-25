﻿module App

open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props

open Fss

type Model = {
    FlexDirection: Flex.Direction
    FlexWrap: Flex.Wraps
    AlignContent: Flex.Alignment
    BackgroundRepeat: Background.Repeat
    BRepeat: Border.ImageRepeat * Border.ImageRepeat option }
type Msg =
    | SetFlexDirection of Flex.Direction
    | SetFlexWrap of Flex.Wraps
    | SetAlignContent of Flex.Alignment
    | SetBackgroundRepeat of Background.Repeat
    | SetBorderImagerRepeat of Border.ImageRepeat * Border.ImageRepeat option

let init() = {
    FlexDirection = Flex.Row
    FlexWrap = Flex.Wrap
    AlignContent = Flex.Center
    BackgroundRepeat = Background.NoRepeat
    BRepeat = Border.Stretch, Option.None}

let update (msg: Msg) (model: Model): Model =
    match msg with
    | SetFlexDirection direction -> { model with FlexDirection = direction}
    | SetFlexWrap wrap -> { model with FlexWrap = wrap}
    | SetAlignContent content -> { model with AlignContent = content}
    | SetBackgroundRepeat repeat -> { model with BackgroundRepeat = repeat}
    | SetBorderImagerRepeat (r, r2) -> { model with BRepeat = r, r2}

let ColorExamples () =
    fragment []
        [
            h1 [] [ str "Color" ]
            p [] [ str "Tons of different ways to style color" ]
            p [ ClassName (fss [Color Color.deepPink]) ] [ str "Named colors like deeppink"]
            p [ ClassName (fss [Color (rgb 255 0 0)])] [ str "Or you can style it using an RGB function!"]
            p [ ClassName (fss [Color (rgba 0 0 0 0.5)])] [ str "We also support RGBA"]
            p [ ClassName (fss [Color (hex "00ff00")])] [ str "or you can use HEX"]
            p [ ClassName (fss [Color (hex "0000ff80")])] [ str "HEX can also be transparent"]
            p [ ClassName (fss [Color (hsl 120 0.5 0.5)])] [ str "Or just use HSL"]
            p [ ClassName (fss [Color (hsla 120 0.5 0.5 0.5)])] [ str "HSL can also be transparent"
            ]
            p [ ClassName (fss [Color Inherit]) ] [ str "Colors can be inherited"]
            p [ ClassName (fss [Color Initial]) ] [ str "Colors can be initialed"]
            p [ ClassName (fss [Color Revert]) ] [ str "Colors can be reverted"]
            p [ ClassName (fss [Color Unset]) ] [ str "Colors can be unset"]
        ]

let BackgroundExamples model dispatch =
    fragment []
        [
            div []
                [
                    h2 [] [ str "Bakground" ]

                    div [ ClassName (fss [
                        BackgroundColor Color.green
                        Height (px 20)
                        Width (px 20)
                    ]) ] []

                    div [ ClassName (fss [
                        BackgroundRepeat Background.NoRepeat
                        BackgroundImage (Image.Url "https://interactive-examples.mdn.mozilla.net/media/examples/lizard.png")
                        Height (px 200)
                        Width (px 200)
                    ]) ] []

                    div [ ClassName (fss [
                        BackgroundOrigin Background.ContentBox
                        BackgroundImage (Image.RadialGradient [Color.crimson; Color.skyBlue])
                        Height (px 60)
                        Width (px 60)
                    ]) ] []

                ]

            h3 [] [ str "And gradients!" ]

            div [ ClassName (fss [Display Display.Flex]) ]
                [
                    div [
                        ClassName (fss
                            [
                                Width (px 200)
                                Height (px 200)
                                BackgroundImage (Image.LinearGradient [ Color.red; Color.blue ])
                            ])
                    ] []

                    div [
                        ClassName (fss
                            [
                                Width (px 200)
                                Height (px 200)
                                BackgroundImage (Image.LinearGradient [ Image.Right; Color.red; Color.blue ] )
                            ])
                    ] []

                    div [
                        ClassName (fss
                            [
                                Width (px 200)
                                Height (px 200)
                                BackgroundImage (Image.RadialGradient [ Color.red; Color.blue ] )
                            ])
                    ] []

                    div [
                        ClassName (fss
                            [
                                Width (px 200)
                                Height (px 200)
                                BackgroundImage (Image.RepeatingRadialGradient [ Color.red; Color.red; px 10; Color.blue; px 10; Color.blue; px 20 ] )
                            ])
                    ] []
                ]

            div [ ClassName (fss [Display Display.Flex]) ]
                [

                    div [
                        ClassName (fss
                            [
                                Width (px 200)
                                Height (px 200)
                                BackgroundImage (Image.RepeatingRadialGradient [ hex "#e66465"; hex "9198e5"; pct 20 ] )
                            ])
                    ] []

                    div [
                            ClassName (fss
                                [
                                    Width (px 200)
                                    Height (px 200)
                                    BackgroundImage (Image.LinearGradient [ Image.Bottom; Color.red; hex "f06d06" ] )
                                ])
                        ] [ ]

                    div [
                            ClassName (fss
                                [
                                    Width (px 200)
                                    Height (px 200)
                                    BackgroundImage (Image.LinearGradient [deg 72.0; Color.red; hex "f06d06" ] )
                                ])
                        ] []

                    div [
                            ClassName (fss
                                [
                                    Width (px 200)
                                    Height (px 200)
                                    BackgroundImage (Image.LinearGradient [ Image.Right; Color.red; hex "f06d06"; rgb 255 255 0; Color.green ] )
                                ])
                        ] []
                ]

            div [ ClassName (fss [Display Display.Flex]) ]
                [

                    div [
                        ClassName (fss
                            [
                                Width (px 200)
                                Height (px 200)
                                BackgroundImage (Image.LinearGradient [ Image.Position.Right; Color.red; Color.yellow; pct 10 ] )
                            ])
                    ] []

                    div [
                            ClassName (fss
                                [
                                    Width (px 200)
                                    Height (px 200)
                                    BackgroundImage (Image.LinearGradient [ Image.Right; hex "fffdc2"; hex "fffdc2"; pct 15; hex "d7f0a2"; pct 15; hex "d7f0a2"; pct 85; hex "fffdc2"; pct 85 ] )
                                ])
                        ] []

                    div [
                            ClassName (fss
                                [
                                    Width (px 200)
                                    Height (px 200)
                                    BackgroundImage (Image.RadialGradient [ Image.CircleAt [ Image.Top; Image.Right]; Color.yellow; hex "f06d06"] )
                                ])
                        ] []

                    div [
                            ClassName (fss
                                [
                                    Width (px 200)
                                    Height (px 200)
                                    BackgroundImage (Image.RadialGradient [ Image.CircleAt [pct 100]; hex "333"; hex "333"; pct 50; hex "eee"; pct 75; hex "333"; pct 75] )
                                ])
                        ] []
                ]

            h3 [] [ str "And images!" ]
            div [
                ClassName (fss
                    [
                        Width (px 200)
                        Height (px 200)
                        BackgroundImage (Image.Url "https://unsplash.it/200/200")
                    ])
            ] []

            let frameAnimation =
                keyframes
                    [
                        frame 0   [ BackgroundPositions [px 0; px 0] ]
                        frame 100 [ BackgroundPositions [px -500; px 0]]
                    ]

            let frame =
                fss
                    [
                        Width (px 50)
                        Height (px 72)
                        BackgroundImage (Image.Url "https://s.cdpn.io/79/sprite-steps.png")
                        AnimationName frameAnimation
                        AnimationDuration (sec 1.0)
                        AnimationTimingFunction (TimingFunction.Step 10)
                        AnimationIterationCount Animation.Infinite
                    ]

            h3 [] [ str "Background images can be... fun?" ]
            div [ ClassName frame ] []

            let formStyle =
                fss
                    [
                        BorderStyle Border.Solid
                        BorderWidth (px 1)
                        BorderColor Color.orangeRed
                        Margin (px 20)
                    ]

            div [ ClassName (fss [ Display Display.Flex])]
                [

                    form [ ClassName formStyle ]
                        [
                            h3 [] [str "Background repeat" ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat Background.RepeatX)) ]
                                    str "Repeat-X"
                                ]

                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat Background.RepeatY)) ]
                                    str "Repeat-Y"
                                ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat Background.Repeat)) ]
                                    str "Repeat"
                                ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat Background.Space)) ]
                                    str "Space"
                                ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat Background.Round)) ]
                                    str "Round"
                                ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat Background.NoRepeat)) ]
                                    str "NoRepeat"
                                ]
                        ]
                    ]
            div [ ClassName (fss
                    [
                        Width (px 1025)
                        Height (px 1025)
                        BackgroundImage (Image.Url "https://interactive-examples.mdn.mozilla.net/media/examples/moon.jpg")
                        BackgroundRepeat model.BackgroundRepeat
                    ])] []

                ]

let FontExamples () =
    fragment []
        [
            h1 [] [ str "fonts" ]
            h2 [] [ str "font-size"]
            p [ClassName (fss
                [
                    FontSize (em 1.2)
                    FontFamily Font.FontFamily.SansSerif
                ])] [ str "1.2em sans serif" ]


            p [ClassName (fss
                [
                    FontStyle Font.Italic
                    FontVariantCaps Font.SmallCaps
                    FontWeight Font.Bold
                    FontSize (px 16)
                    LineHeight (px 2)
                    FontFamily Font.Cursive
            ])] [ str "italic small-caps bold 16px 2 line height cursive" ]



            h2 [] [ str "font-size"]
            p [ClassName (fss [FontSize Font.XxSmall])] [ str "Fonts can be xx-Small" ]
            p [ClassName (fss [FontSize Font.XSmall])] [ str "Fonts can be x-Small" ]
            p [ClassName (fss [FontSize Font.Small])] [ str "Fonts can be small" ]
            p [ClassName (fss [FontSize Font.Medium])] [ str "Fonts can be medium" ]
            p [ClassName (fss [FontSize Font.Large])] [ str "Fonts can be large" ]
            p [ClassName (fss [FontSize Font.XLarge])] [ str "Fonts can be x-large" ]
            p [ClassName (fss [FontSize Font.XxLarge])] [ str "Fonts can be xx-large" ]
            p [ClassName (fss [FontSize Font.XxxLarge])] [ str "Fonts can be xxx-large" ]
            p [ClassName (fss [FontSize Font.Smaller])] [ str "Fonts can be smaller" ]
            p [ClassName (fss [FontSize Font.Larger])] [ str "Fonts can be larger" ]

            p [ClassName (fss [FontSize (px 28)])] [ str "Fonts can be set with pixels" ]
            p [ClassName (fss [FontSize (pct 300)])] [ str "Fonts can be set with percent" ]
            p [ClassName (fss [FontSize (em 2.5)])] [ str "Fonts can be set with ems" ]
            p [ClassName (fss [FontSize (rem 3.0)])] [ str "Fonts can be set with rems" ]
            p [ClassName (fss [FontSize (cm 3.3)])] [ str "Fonts can be set with cm" ]
            p [ClassName (fss [FontSize (mm 33.3)])] [ str "Fonts can be set with mm" ]
            p [ClassName (fss [FontSize Inherit])] [ str "Fonts can inherited" ]
            p [ClassName (fss [FontSize Initial])] [ str "Fonts can initial" ]
            p [ClassName (fss [FontSize Revert])] [ str "Fonts can reverted" ]
            p [ClassName (fss [FontSize Unset])] [ str "Fonts can unset" ]

            p [ ClassName (fss [FontFamily Font.Serif]) ] [ str "This font is serif!"]
            p [ ClassName (fss [FontFamily Font.SansSerif]) ] [ str "This font is sans-serif!"]
            p [ ClassName (fss [FontFamily Font.Monospace]) ] [ str "This font is monospace!"]
            p [ ClassName (fss [FontFamily Font.Cursive]) ] [ str "This font is cursive!"]
            p [ ClassName (fss
                    [
                        FontFamilies [ Font.SansSerif; Font.Custom "Helvetica" ]
                    ]) ] [ str "This should be helvetica sans-serif"]


            p [ ClassName (fss [FontStyle Font.Italic])]
                [
                    str "Italic"
                ]
            p [ ClassName (fss [FontStyle Font.Normal])]
                [
                    str "Normal"
                ]
            p [ ClassName (fss [FontStyle (Font.Oblique <| deg 90.0) ])]
                [
                    str "Oblique 90"
                ]
            p [ ClassName (fss [FontStyle (Font.Oblique <| deg -90.0) ])]
                [
                    str "Oblique -90"
                ]

            p [ ClassName (fss [FontWeight Font.Bold ])]
                [
                    str "BOLD"
                ]

            p [ ClassName (fss [FontWeight (Font.Value 700) ])]
                [
                    str "BOLD"
                ]

            p [ ClassName (fss
                    [
                        Width (px 150)
                        LineHeight Font.LineHeight.Normal
                    ])]
                [
                    str """
                    Far out in the uncharted
                    backwaters of the unfashionable end of the western spiral arm of the Galaxy lies a small unregarded yellow sun.
                    """
                ]

            p [ ClassName (fss
                    [
                        Width (px 150)
                        LineHeight (Font.LineHeight.Value 2.5)
                    ])]
                [
                    str """
                    Far out in the uncharted
                    backwaters of the unfashionable end of the western spiral arm of the Galaxy lies a small unregarded yellow sun.
                    """
                ]

            p [ ClassName (fss
                    [
                        Width (px 150)
                        LineHeight (em 3.0)
                    ])]
                [
                    str """
                    Far out in the uncharted
                    backwaters of the unfashionable end of the western spiral arm of the Galaxy lies a small unregarded yellow sun.
                    """
                ]

            p [ ClassName (fss
                    [
                        Width (px 150)
                        LineHeight (pct 150)
                    ])]
                [
                    str """
                    Far out in the uncharted
                    backwaters of the unfashionable end of the western spiral arm of the Galaxy lies a small unregarded yellow sun.
                    """
                ]

            p [ ClassName (fss
                    [
                        Width (px 150)
                        LineHeight (px 32)
                    ])]
                [
                    str """
                    Far out in the uncharted
                    backwaters of the unfashionable end of the western spiral arm of the Galaxy lies a small unregarded yellow sun.
                    """
                ]
        ]

let FontFaceExamples () =
    let droidSerif =
        fontFaces "DroidSerif"
            [
                [
                    FontFace.Source (FontFace.Url ("https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf", FontFace.Truetype))
                    FontFace.FontWeight Font.Bold
                    FontFace.FontStyle Normal
                ]
                [
                    FontFace.Source (FontFace.Url ("https://rawgit.com/google/fonts/master/ufl/ubuntumono/UbuntuMono-Italic.ttf", FontFace.Truetype))
                    FontFace.FontWeight Normal
                    FontFace.FontStyle Normal
                ]
            ]

    let moderna =
        fontFace "moderna"
            [
                FontFace.Sources
                    [
                        FontFace.Url ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff2", FontFace.Woff2)
                        FontFace.Url ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff", FontFace.Woff)
                        FontFace.Url ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.ttf", FontFace.Truetype)
                        FontFace.Url ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.svg", FontFace.Svg)
                    ]
                FontFace.FontWeight Normal
                FontFace.FontStyle Normal
            ]

    let p1 =
        fss
            [
                FontFamily (Font.Font droidSerif)
            ]

    let p2 =
        fss
            [
                FontFamily (Font.Font droidSerif)
                FontWeight Font.Bold
            ]

    let p3 =
        fss
            [
                FontFamily (Font.Font moderna)
                FontWeight Font.Bold
            ]

    fragment []
        [
            h2 [] [ str "Font face examples" ]

            p [ ClassName p1 ]
                [
                    str "Why..."
                ]

            p [ ClassName p2 ]
                [
                    str "Hello there"
                ]

            p [ ClassName p3 ]
                [
                    str "Hello there"
                ]
        ]

let BorderExamples (model: Model) dispatch =
    fragment []
        [
            h1 [] [ str "borders"]
            h2 [] [ str "Set unique borders"]
            p [ ClassName (fss [BorderStyle Border.Solid ])] [ str "I have a solid border" ]
            p [ ClassName (fss [BorderStyle Border.Double ])] [ str "I have a double border"]
            p [ ClassName (fss [BorderStyle Border.Groove])] [ str "I have a groove border"]
            p [ ClassName (fss [BorderStyle Border.Inset])] [ str "I have an inset border"]
            p [ ClassName (fss [BorderStyle Border.Ridge])] [ str "I have a ridge border"]
            p [ ClassName (fss [BorderStyle Border.Dashed])] [ str "I have a dashed border"]
            p [ ClassName (fss [BorderStyle Border.Dotted])] [ str "I have a dotted border"]
            p [ ClassName (fss [BorderStyle Border.Outset])] [ str "I have an outset border"]
            p [ ClassName (fss [BorderStyle Border.Hidden])] [ str "I have a hidden border"]
            p [ ClassName (fss [BorderStyle Border.None])] [ str "I don't have a border"]
            p [ ClassName (fss [BorderStyles [Border.Groove; Border.Dotted; Border.Solid; Border.Dashed]])] [ str "I have a mixed border"]
            p [] [ str "We can also apply only border width" ]
            p [ ClassName (fss
                    [
                        BorderWidth Border.Thin
                        BorderStyle Border.Solid
                    ])] [ str "I have a thin border" ]
            p [ ClassName (fss
                    [
                        BorderWidth (px 3)
                        BorderStyle Border.Solid
                    ])] [ str "I have a 3px border" ]
            p [ ClassName (fss
                    [
                        BorderWidths [px 3; px 4; px 5; px 6]
                        BorderStyle Border.Solid
                    ])] [ str "I have a mixed width border" ]
            p [ ClassName (fss [
                    BorderStyle Border.Double
                    BorderWidth Border.Thick
                    BorderColor Color.green
                ])] [ str "BorderStyles" ]
            p [ ClassName (fss
                    [
                        BorderStyle Border.Solid
                        BorderTopWidth (px 10)
                    ])] [ str "top width" ]
            p [ ClassName (fss
                    [
                        BorderStyle Border.Solid
                        BorderRightWidth (px 10)
                    ])] [ str "right width" ]
            p [ ClassName (fss
                    [
                        BorderStyle Border.Solid
                        BorderBottomWidth (px 10)
                    ])] [ str "bottom width" ]
            p [ ClassName (fss
                    [
                        BorderStyle Border.Solid
                        BorderLeftWidth (px 10)
                    ])] [ str "left width" ]
            p [ ClassName (fss
                    [
                        Color Color.white
                        BackgroundColor Color.purple
                        BorderRadiuses [px 10; px (100 / 120) ]
                    ])] [ str "Border radius!"]
            p [ ClassName (fss
                    [
                        Color Color.yellowGreen
                        BackgroundColor Color.purple
                        BorderTopLeftRadius (px 10)
                    ])] [ str "Top left Border radius!"]
            p [ ClassName (fss
                    [
                        BorderStyle Border.Solid
                        BorderWidth (px 15)
                        BorderColors [Color.red; rgba 170 50 220 0.6; Color.green]
                    ]
            )] [ str "Now in color!"]

            p [ ClassName (fss
                    [
                        BorderStyle Border.Dashed
                        BorderWidth (px 15)
                        BorderTopWidth (px 20)
                        BorderTopColor Color.deepPink
                        BorderBottomWidth (px 1)
                        BorderLeftWidth (px 10)
                        BorderRightWidth (px 10)
                        BorderLeftColor Color.gold
                        BorderRightColor Color.rosyBrown
                    ]
            )] [ str "Now in color!"]

            let tableStyle =
                fss
                    [
                        Margins [rem 2.; Auto]
                        BorderStyle Border.Solid
                        BorderWidth (px 1)
                        BorderColor Color.red
                        BorderCollapse Border.Separate
                        BorderSpacing (rem 1.)
                        BackgroundColor Color.khaki
                    ]

            let theadStyle =
                fss
                    [
                        FontWeight (Font.Weight.Value 500)
                        BackgroundColor Color.white
                    ]

            let trStyle =
                fss
                    [
                        BackgroundColor Color.aquaMarine

                        ! Html.Th
                            [
                                BorderStyle Border.Solid
                                BorderWidth (px 1)
                                BorderColor Color.red
                                BackgroundColor Color.goldenrod
                            ]
                    ]

            let tbodyStyle =
                fss
                    [
                        BackgroundColor Color.lime

                        ! Html.Tr
                            [
                                BackgroundColor Color.aquaMarine

                                NthChild ("odd",
                                    [
                                        BackgroundColor Color.gray
                                    ])
                            ]

                        ! Html.Td
                            [
                                BorderStyle Border.Solid
                                BorderWidth (px 1)
                                BorderColor Color.red
                                Padding (rem 1.0)
                            ]
                    ]

            table [ ClassName tableStyle ]
                [
                    thead [ ClassName theadStyle ]
                        [
                            tr [ ClassName trStyle ]
                                [
                                    th [] [ str "Heading" ]
                                    th [] [ str "Heading" ]
                                    th [] [ str "Heading" ]
                                ]
                        ]
                    tbody [ ClassName tbodyStyle ]
                        [
                            tr []
                                [
                                  td [] [str "data" ]
                                  td [] [str "data" ]
                                  td [] [str "data" ]
                                ]
                            tr []
                                [
                                  td [] [str "data" ]
                                  td [] [str "data" ]
                                  td [] [str "data" ]
                                ]
                            tr []
                                [
                                  td [] [str "data" ]
                                  td [] [str "data" ]
                                  td [] [str "data" ]
                                ]
                            tr []
                                [
                                  td [] [str "data" ]
                                  td [] [str "data" ]
                                  td [] [str "data" ]
                                ]
                        ]
                    ]

            h2 [] [ str "Border image" ]
            div  [
                ClassName (fss [
                    Width (px 100)
                    Height (px 100)
                    BorderWidth (px 30)
                    BorderStyle Border.Solid
                    BorderImageSource (Image.Url "https://interactive-examples.mdn.mozilla.net/media/examples/border-diamonds.png")
                    BorderImageWidth (Border.Value 30.)
                ])
            ]
                []

            div [
                ClassName (fss [
                    Width (rem 12.)
                    Height (rem 12.)
                    MarginBottom (rem 1.)
                    Padding (rem 1.)
                    BorderWidth (px 40)
                    BorderStyle Border.Solid
                    BorderImageSource (Image.Url "https://mdn.mozillademos.org/files/4127/border.png" )
                    BorderImageSlice (Border.Value 27.)

                    let (first, optional) = model.BRepeat

                    match optional with
                        | Some b -> BorderImageRepeat2(first, b)
                        | Option.None -> BorderImageRepeat first
                ])
            ]
                [
                    str "Pick something!"
                ]
            form [  ]
                [
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBorderImagerRepeat (Border.Stretch, Option.None))) ]
                            str "Stretch"
                        ]

                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBorderImagerRepeat (Border.Repeat, Option.None))) ]
                            str "Repeat"
                        ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBorderImagerRepeat (Border.Round, Option.None))) ]
                            str "Round"
                        ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBorderImagerRepeat (Border.Space, Option.None))) ]
                            str "Space"
                        ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBorderImagerRepeat (Border.Stretch, Some Border.Repeat))) ]
                            str "Stretch repeat"
                        ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBorderImagerRepeat (Border.Space, Some Border.Round))) ]
                            str "Space round"
                        ]
                ]


            h2 [] [ str "Combining" ]
            let borderStuff =
                [
                    BorderWidth (px 7)
                    BorderStyle Border.Solid
                ]

            let colorStuff =
                [
                    Color Color.orangeRed
                    yield! borderStuff
                    BackgroundColor Color.green
                    Height (px 20)
                    Width (px 200)
                ]

            let borderAndColorStyle = fss colorStuff

            div [ ClassName borderAndColorStyle ] [ str "I AM COOL?" ]
    ]

let MarginExamples () =
    fragment []
        [
            div [
                    ClassName
                        (fss
                            [
                                Width (px 100)
                                Height (px 100)
                                Color Color.orangeRed
                                BackgroundColor Color.rebeccaPurple
                                MarginRight (px 50)
                                MarginLeft (px 50)
                                MarginTop (px 50)
                                MarginBottom (px 50)
                            ])
                ]
                [ str "I have margin everywhere!" ]

            div [
                    ClassName
                        (fss
                            [
                                Width (px 100)
                                Height (px 100)
                                Color Color.orangeRed
                                BackgroundColor Color.rebeccaPurple
                                Margins [px 100; px 50; px 200; px 150]
                            ])
                ]
                [ str "Me tooo!" ]
        ]

let PaddingExamples () =
    fragment []
        [
            div [
                    ClassName
                        (fss
                            [
                                Width (px 100)
                                Height (px 100)
                                Color Color.darkOrange
                                BackgroundColor Color.rebeccaPurple
                                PaddingRight (px 50)
                                PaddingLeft (px 50)
                                PaddingTop (px 50)
                                PaddingBottom (px 50)
                            ])
                ]
                [ str "I have padding everywhere!" ]

            div [
                    ClassName
                        (fss
                            [
                                Width (px 100)
                                Height (px 100)
                                Color Color.orangeRed
                                BackgroundColor Color.rebeccaPurple
                                Paddings [px 100; px 50; px 200; px 150]
                            ])
                ]
                [ str "Me tooo!" ]
        ]

let TransformExamples () =
    fragment []
        [
            h3 [] [ str "Transforms" ]
            div [
                ClassName
                    (fss
                        [
                            Width (px 50)
                            Height (px 50)
                            BackgroundColor Color.red
                            Transform (Transform.Skew2(deg 30.0, deg 20.0))
                        ])
            ] []

            div [
                ClassName
                    (fss
                        [
                            Width (px 50)
                            Height (px 50)
                            BackgroundColor Color.orange
                            Transform (Transform.Matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0))
                        ])
            ] []

            div [
                ClassName
                    (fss
                        [
                            Width (px 50)
                            Height (px 50)
                            BackgroundColor Color.blue
                            Transform Inherit
                        ])
            ] []

            let spinningAnimation =
                keyframes
                    [
                        frame 0 [ Transform(Transform.Rotate (deg 360.0)) ]
                        frame 100 [ Transform(Transform.Rotate (deg 0.0)) ]
                    ]

            let spinningCube =
                fss
                    [
                        Width (px 100)
                        Height (px 100)
                        BackgroundColor Color.orangeRed
                        AnimationName spinningAnimation
                        AnimationDuration (sec 2.0)
                        AnimationIterationCount Animation.Infinite
                        AnimationTimingFunction TimingFunction.Linear

                    ]

            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigins [ Transform.Top; Transform.Left ] ]) )] []
            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigins [ Transform.Top; Transform.Center ] ]) )] []
            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigins [ Transform.Top; Transform.Right ] ]) )] []

            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigins [ Transform.Center; Transform.Left ] ]) )] []
            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigins [ Transform.Center; Transform.Center ] ]) )] []
            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigins [ Transform.Center; Transform.Right ] ]) )] []

            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigins [ Transform.Bottom; Transform.Left ] ]) )] []
            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigins [ Transform.Bottom; Transform.Center ] ]) )] []
            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigins [ Transform.Bottom; Transform.Right ] ]) )] []
        ]

let TransitionExamples () =
    let trigger =
        fss
            [
                Width (px 200)
                Height (px 200)
                BorderWidth (px 20)
                BorderStyle Border.Solid
                BorderColor (hex "ddd")
                Hover
                    [
                        ! Html.Div
                            [
                                Transforms
                                    [
                                        Transform.Translate2((px 200), (px 150))
                                        Transform.Rotate(deg 20.0)
                                    ]
                            ]
                    ]

                ! Html.Div
                    [
                        Display Display.InlineBlock
                        BackgroundColor Color.pink
                        Width (px 200)
                        Height (px 200)
                        TransitionProperty Property.Transform
                        TransitionDuration (ms 300.0)
                        TransitionTimingFunction (TimingFunction.CubicBezier(0.0, 0.47, 0.32, 1.97))
                    ]
            ]

    fragment []
        [
            h2 [] [str "Transition shorthand"]

            let widthAndPosition =
                    [
                        Width (pct 50)
                        Margins [ px 0; Auto; px 40]
                        Position Position.Relative
                        TransitionTimingFunction TimingFunction.EaseOut
                        TransitionDuration (sec 0.5)
                    ]

            let shadow =
                [
                    Color (hex "E39F81")
                    TextShadow (Text.Shadow(px 1, px 1, px 0, (hex "FFE3BD")))
                    Hover
                        [
                            TextShadows
                                [
                                    Text.Shadow(px 1, px 1, px 0, hex "FFE3BD")
                                    Text.Shadow(px 2, px 2, px 0, hex "FFE3BD")
                                    Text.Shadow(px 3, px 3, px 0, hex "FFE3BD")
                                    Text.Shadow(px 4, px 4, px 0, hex "FFE3BD")
                                    Text.Shadow(px 5, px 5, px 0, hex "FFE3BD")
                                ]
                        ]
                ] @ widthAndPosition
                |> fss

            let box =
                widthAndPosition @
                    [
                        BorderWidth (px 5)
                        BorderStyle Border.Solid
                        BorderColor Color.transparent
                        Width (px 200)
                        Height (px 100)
                        Margins [px 0; Auto]
                        Padding (px 10)
                    ]

            let one =
                box @
                    [
                        BackgroundColor (hex "B0CBC4")
                        Hover
                            [
                                BackgroundColor (hex "F2EBD8")
                                BorderWidth (px 5)
                                BorderStyle Border.Solid
                                BorderColor (hex "B0CBC4")
                                BorderTopLeftRadiuses [pct 100; px 20]
                                BorderBottomRightRadiuses [pct 100; px 20]
                            ]
                    ] |> fss

            let box = box |> fss

            div [ ClassName shadow ]
                [
                    h2 [] [ str "Text-shadow" ]
                ]

            div [ ClassName one ]
                [
                    str "border-color, border-radius, background-color"
                ]

            h3 [] [str "Other transitions"]
            div [ ClassName trigger ]
                [
                    div [] []
                ]

            p [ClassName (fss [
                BackgroundColor Color.red
                TransitionProperty Property.BackgroundColor
                TransitionDuration (sec 2.5)
                TransitionDelay (sec 2.5)
                TransitionTimingFunction TimingFunction.Ease
                Hover
                    [
                        BackgroundColor Color.green
                    ]
            ])] [ str "I have a transition! Hover me!" ]
        ]

let TextExamples () =
    fragment []
        [
            let style =
                fss
                    [
                        Width (px 200)
                        Height (px 100)
                        TextAlign Text.Right
                    ]

            div [ ClassName style ]
                [
                    str "I am to the right"
                ]

            div [ ClassName (fss [ TextDecorationLine Text.Underline])] [str "Underline" ]
            div [ ClassName (fss [ TextDecorationLine Text.Overline])] [str "Overline" ]
            div [ ClassName (fss [ TextDecorationLine Text.LineThrough])] [str "Line-Through" ]
            div [ ClassName (fss [ TextDecorationLines [ Text.Underline; Text.Overline; Text.LineThrough] ])] [str "This one has all three" ]

            div [ ClassName (fss
                    [
                        TextDecorationLines [ Text.Underline; Text.Overline; Text.LineThrough]
                        TextDecorationColor Color.orangeRed
                    ]
                )] [str "This one has all three and are red" ]


            div [ ClassName (fss
                    [
                        TextDecorationLine Text.Underline
                        TextDecorationColor Color.red
                        TextDecorationThickness Text.FromFont
                    ])] [str "Thickness from font" ]

            div [ ClassName (fss
                    [
                        TextDecorationLine Text.Underline
                        TextDecorationColor Color.red
                        TextDecorationThickness Auto
                    ])] [str "Thickness from auto" ]

            div [ ClassName (fss
                    [
                        TextDecorationLine Text.Underline
                        TextDecorationColor Color.red
                        TextDecorationThickness (pct 100)
                    ])] [str "Thickness from percent" ]

            div [ ClassName (fss
                    [
                        TextDecorationLine Text.Underline
                        TextDecorationColor Color.red
                        TextDecorationThickness (px 1)
                    ])] [str "Thickness from pixels" ]

            div [ ClassName (fss [ TextDecorationLine Text.Underline; TextDecorationStyle Text.Solid])] [str "Solid" ]
            div [ ClassName (fss [ TextDecorationLine Text.Underline; TextDecorationStyle Text.Double])] [str "Double" ]
            div [ ClassName (fss [ TextDecorationLine Text.Underline; TextDecorationStyle Text.Dotted])] [str "Dotted" ]
            div [ ClassName (fss [ TextDecorationLine Text.Underline; TextDecorationStyle Text.Dashed])] [str "Dashed" ]
            div [ ClassName (fss [ TextDecorationLine Text.Underline; TextDecorationStyle Text.Wavy])] [str "Wavy" ]

            div [ ClassName (fss [ TextTransform Text.Capitalize ])] [str "capitalize" ]
            div [ ClassName (fss [ TextTransform Text.Uppercase ])] [str "uppercase" ]
            div [ ClassName (fss [ TextTransform Text.Lowercase ])] [str "LOWERCASE" ]
            div [ ClassName (fss [ TextTransform None ])] [str "NoNE" ]
            div [ ClassName (fss [ TextTransform Text.FullWidth ])] [str "FullWidth" ]
            div [ ClassName (fss [ TextTransform Text.FullSizeKana ])] [str "FullSizeKana" ]

            div [ ClassName (fss [ Width (px 200); TextIndent (px 10)])] [str "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt."]
            div [ ClassName (fss [ Width (px 200); TextIndent (pct 10)])] [str "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt."]
            div [ ClassName (fss [ Width (px 200); TextIndent (pct -10)])] [str "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt."]
            div [ ClassName (fss [ Width (px 200); TextIndents [pct 10; Text.EachLine]])] [str "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt."]
            div [ ClassName (fss [ Width (px 200); TextIndents [pct 10; Text.Hanging]])] [str "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt."]

            let simple =
                fss
                    [
                        TextAlign Text.Center
                        FontWeight Font.Bold
                        FontSize (px 80)
                        FontFamily Font.SansSerif
                        BackgroundColor (hex "91877b")
                        TextShadow (Text.Shadow (px 0, px 1, px 0, rgba 255 255  255 0.4))
                    ]

            h1 [ ClassName simple ] [ str "Monster Mash" ]

            let otto =
                fss
                    [
                        TextAlign Text.Center
                        FontWeight Font.Bold
                        FontSize (px 80)
                        FontFamily Font.SansSerif
                        BackgroundColor (hex "0e8dbc")
                        Color Color.white
                        Height (px 100)
                        TextShadows
                            [
                                Text.Shadow (px 0, px  1, px  0, hex "ccc")
                                Text.Shadow (px 0, px  2, px  0, hex "#c9c9c9")
                                Text.Shadow (px 0, px  3, px  0, hex "#bbb")
                                Text.Shadow (px 0, px  4, px  0, hex "#b9b9b9")
                                Text.Shadow (px 0, px  5, px  0, hex "#aaa")
                                Text.Shadow (px 0, px  6, px  1, rgba 0 0 0 0.1)
                                Text.Shadow (px 0, px  0, px  5, rgba 0 0 0 0.1)
                                Text.Shadow (px 0, px  1, px  3, rgba 0 0 0 0.3)
                                Text.Shadow (px 0, px  3, px  5, rgba 0 0 0 0.2)
                                Text.Shadow (px 0, px  5, px 10, rgba 0 0 0 0.25)
                                Text.Shadow (px 0, px 10, px 10, rgba 0 0 0 0.2)
                                Text.Shadow (px 0, px 20, px 20, rgba 0 0 0 0.15)
                            ]
                    ]

            h1 [ ClassName otto ] [ str "Slippery Slime" ]

            let close =
                fss
                    [
                        TextAlign Text.Center
                        FontWeight Font.Bold
                        FontSize (px 80)
                        FontFamily Font.SansSerif
                        BackgroundColor (hex "3a50d9")
                        Color (hex "e0eff2")
                        Height (px 100)
                        TextShadows
                            [
                                Text.Shadow (px  -4, px 3, px 0, hex "#3a50d9")
                                Text.Shadow (px -14, px 7, px 0, hex "#0a0e27")
                            ]
                    ]

            h1 [ ClassName close ] [ str "Mummy mummy" ]

            let printers =
                fss
                    [
                        TextAlign Text.Center
                        FontWeight Font.Bold
                        FontSize (px 80)
                        FontFamily Font.SansSerif
                        BackgroundColor (hex "edde9c")
                        Color (hex "bc2e1e")
                        Height (px 100)
                        TextShadows
                            [
                                Text.Shadow (px 0, px 1, px 0, hex "#378ab4")
                                Text.Shadow (px 1, px 0, px 0, hex "#5dabcd")
                                Text.Shadow (px 1, px 2, px 1, hex "#378ab4")
                                Text.Shadow (px 2, px 1, px 1, hex "#5dabcd")
                                Text.Shadow (px 2, px 3, px 2, hex "#378ab4")
                                Text.Shadow (px 3, px 2, px 2, hex "#5dabcd")
                                Text.Shadow (px 3, px 4, px 2, hex "#378ab4")
                                Text.Shadow (px 4, px 3, px 3, hex "#5dabcd")
                                Text.Shadow (px 4, px 5, px 3, hex "#378ab4")
                                Text.Shadow (px 5, px 4, px 2, hex "#5dabcd")
                                Text.Shadow (px 5, px 6, px 2, hex "#378ab4")
                                Text.Shadow (px 6, px 5, px 2, hex "#5dabcd")
                                Text.Shadow (px 6, px 7, px 1, hex "#378ab4")
                                Text.Shadow (px 7, px 6, px 1, hex "#5dabcd")
                                Text.Shadow (px 7, px 8, px 0, hex "#378ab4")
                                Text.Shadow (px 8, px 7, px 0, hex "#5dabcd")
                            ]
                    ]

            h1 [ ClassName printers ] [ str "Skeleton crew" ]

            let vamp =
                fss
                    [
                        TextAlign Text.Center
                        FontWeight Font.Bold
                        FontSize (px 80)
                        FontFamily Font.SansSerif
                        BackgroundColor Color.red
                        Color (hex "92a5de")
                        Height (px 100)
                        TextShadows
                            [
                                Text.Shadow(px  0, px  0, px  0, rgb 137 156 213)
                                Text.Shadow(px  1, px  1, px  0, rgb 129 148 205)
                                Text.Shadow(px  2, px  2, px  0, rgb 120 139 196)
                                Text.Shadow(px  3, px  3, px  0, rgb 111 130 187)
                                Text.Shadow(px  4, px  4, px  0, rgb 103 122 179)
                                Text.Shadow(px  5, px  5, px  0, rgb 94  113 170)
                                Text.Shadow(px  6, px  6, px  0, rgb 85  104 161)
                                Text.Shadow(px  7, px  7, px  0, rgb 76   95 152)
                                Text.Shadow(px  8, px  8, px  0, rgb 68   87 144)
                                Text.Shadow(px  9, px  9, px  0, rgb 59   78 135)
                                Text.Shadow(px 10, px 10, px  0, rgb 50   69 126)
                                Text.Shadow(px 11, px 11, px  0, rgb 42   61 118)
                                Text.Shadow(px 12, px 12, px  0, rgb 33   52 109)
                                Text.Shadow(px 13, px 13, px  0, rgb 24   43 100)
                                Text.Shadow(px 14, px 14, px  0, rgb 15   34  91)
                                Text.Shadow(px 15, px 15, px  0, rgb 7    26  83)
                                Text.Shadow(px 16, px 16, px  0, rgb -2   17  74)
                                Text.Shadow(px 17, px 17, px  0, rgb -11   8  65)
                                Text.Shadow(px 18, px 18, px  0, rgb -19   0  57)
                                Text.Shadow(px 19, px 19, px  0, rgb -28  -9  48)
                                Text.Shadow(px 20, px 20, px  0, rgb -37 -18  39)
                                Text.Shadow(px 21, px 21, px 20, rgba 0    0   0 1.0)
                                Text.Shadow(px 21, px 21, px  1, rgba 0    0   0 0.5)
                                Text.Shadow(px  0, px  0, px 20, rgba 0    0   0 0.2)
                            ]
                    ]

            h1 [ ClassName vamp ] [ str "Vampire Diaries" ]
        ]

let AnimationExamples () =

    let bounceFrames =
        keyframes
            [
                frames [ 0; 20; 53; 80; 100 ]
                    [
                        Transform (Transform.Translate3D(px 0, px 0, px 0))
                        BackgroundColor Color.red
                    ]
                frames [40; 43]
                    [
                        Transform (Transform.Translate3D(px 0, px -30, px 0))
                        BackgroundColor Color.blue
                    ]
                frame 70
                    [
                        Transform (Transform.Translate3D(px 0, px -15, px 0))
                        BackgroundColor Color.green
                    ]
                frame 90
                    [
                        Transform (Transform.Translate3D(px 0, px -4, px 0))
                        BackgroundColor Color.orange
                    ]
            ]

    let sizeFrames =
        keyframes
            [
                frame 0 [ FontSize (pct 50) ]
                frame 50 [ FontSize (pct 150) ]
                frame 100 [ FontSize (pct 50) ]
            ]

    let spinnyFrames =
        keyframes
            [
                frame 0 [ Transform (Transform.Rotate(deg 0.0))]
                frame 100 [ Transform (Transform.Rotate(deg 360.0))]
            ]

    let bounceAnimation =
        fss
            [
                AnimationName bounceFrames
                AnimationDuration (sec 1.0)
                AnimationTimingFunction TimingFunction.Ease
                AnimationIterationCount Animation.Infinite
            ]

    let sizeAnimation =
        fss
            [
                AnimationName sizeFrames
                AnimationDuration (sec 3.0)
                AnimationTimingFunction TimingFunction.EaseInOut
                AnimationIterationCount (Animation.IterationCount.Value 3)
            ]

    let combinedAnimations =
        fss
            [
                AnimationNames [ bounceFrames; sizeFrames ]
                AnimationDurations [ sec 1.0; sec 3.0 ]
                AnimationTimingFunctions [ TimingFunction.EaseInOut; TimingFunction.Ease ]
                AnimationIterationCounts [ Animation.Value 3; Animation.Infinite ]
            ]

    let spinnyMation =
        fss
            [
                Width (px 200)
                Height (px 200)
                BackgroundColor Color.orangeRed
                AnimationName spinnyFrames
                AnimationDuration (sec 5.0)
                AnimationIterationCount Animation.Infinite
                AnimationTimingFunction TimingFunction.Linear
            ]

    let loader =
        keyframes
            [
                frame 0 [ Transforms [ Transform.RotateX(deg 0.0); Transform.RotateY(deg 0.0) ] ]
                frame 50 [ Transforms [ Transform.RotateX(deg 0.0); Transform.RotateY(deg 180.0) ] ]
                frame 100 [ Transforms [ Transform.RotateX(deg 180.0); Transform.RotateY(deg 180.0) ] ]
            ]

    let loaderParent =
        fss
            [
                Height (px 200)
                Width (px 200)
                Display Display.Flex
                JustifyContent Center
                AlignItems Center
                BackgroundColor (hex "272727")
                Perspective (px 200)
            ]

    let loaderContainer =
        fss
            [
                Width (px 100)
                Height (px 100)
                BorderRadius (px 12)
                BackgroundColor (hex "00dbde")
                AnimationName loader
                AnimationDuration (sec 2.0)
                AnimationTimingFunction TimingFunction.Linear
                AnimationIterationCount Animation.Infinite
            ]

    let stretch =
        fss
            [
                Height (px 250)
                Width (px 250)
                Margins [px 0; Auto]
                BackgroundColor Color.red
                AnimationDuration (sec 1.5)
                AnimationTimingFunction TimingFunction.EaseOut
                AnimationDelay (sec 0.0)
                AnimationDirection Animation.Alternate
                AnimationIterationCount Animation.Infinite
                AnimationFillMode None
                AnimationPlayState Animation.Running
                AnimationName (keyframes
                                       [
                                           frame 0
                                               [
                                                   Transform (Transform.Scale 0.3)
                                                   BackgroundColor Color.red
                                                   BorderRadius (pct 100)
                                               ]
                                           frame 50
                                               [
                                                   BackgroundColor Color.orange
                                               ]
                                           frame 100
                                               [
                                                    Transform (Transform.Scale 1.5)
                                                    BackgroundColor Color.yellow
                                               ]
                                       ])
            ]

    fragment []
        [
            p [] [ str "Things can animate now!" ]
            div [ ClassName stretch ] []
            p [ClassName bounceAnimation] [str "Bouncing text"]
            p [ClassName sizeAnimation] [str "Weeeeeeeeee"]
            p [ClassName combinedAnimations] [str "COMBINED"]
            div [ ClassName spinnyMation ] []
            div [ ClassName loaderParent]
                [
                    div [ ClassName loaderContainer ] []
                ]
        ]

let FlexBoxExamples model dispatch =
    // Set display to None
    let foo =
        fss
            [
                Display None
            ]

    // Test alignment
    let parent =
        fss
            [
                Display Display.Flex
                Height (px 300)
                BackgroundColor Color.grey
            ]

    let child =
        fss
            [
                Width (px 100)
                Height (px 100)
                Margin Margin.Auto
                BackgroundColor Color.lightCoral
            ]

    let alignment =
        div [ ClassName parent]
             [
                div [ ClassName child] []
             ]

    // Test Flex flow property
    let parent =
        fss
            [
                Display Display.Flex
                FlexDirection Flex.Row
                FlexWrap Flex.Wrap
                JustifyContent Flex.SpaceAround
            ]

    let child =
        fss
            [
                BackgroundColor Color.tomato
                Width (px 200)
                Height (px 150)
                MarginTop (px 10)
            ]

    let flow =
        div [ ClassName parent]
             [
                 div [ ClassName child] []
                 div [ ClassName child] []
                 div [ ClassName child] []
                 div [ ClassName child] []
                 div [ ClassName child] []
                 div [ ClassName child] []
             ]

    // Flex Direction row
    let parent =
        fss
            [
                Display Display.Flex
                FlexDirection Flex.Row
            ]

    let child =
        fss
            [
                BackgroundColor Color.tomato
                Width (px 50)
                Height (px 50)
                MarginLeft (px 10)
            ]


    let rows =
        div [ ClassName parent]
                [
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                ]

    // Flex Direction column
    let parent =
        fss
            [
                Display Display.Flex
                FlexDirection Flex.Column
            ]

    let child =
        fss
            [
                BackgroundColor Color.tomato
                Width (px 50)
                Height (px 50)
                MarginTop (px 10)
            ]

    let columns =
        div [ ClassName parent]
                [
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                ]

    // Flex no wrap
    let parent =
        fss
            [
                Display Display.Flex
                Width (em 40.0)
                FlexWrap Flex.NoWrap
            ]

    let child =
        fss
            [
                BackgroundColor (hex "#cee")
                Width (em 15.0)
                Margin (px 10)
            ]

    let noWrap =
        div [ ClassName parent]
                [
                    div [ ClassName child] [ str "1" ]
                    div [ ClassName child] [ str "2" ]
                    div [ ClassName child] [ str "3" ]
                    div [ ClassName child] [ str "4" ]
                ]

    // Flex no wrap
    let parent =
        fss
            [
                Display Display.Flex
                Width (em 40.0)
                FlexWrap Flex.Wrap
            ]

    let child =
        fss
            [
                BackgroundColor (hex "#cee")
                Width (em 15.0)
                Margin (px 10)
            ]

    let wrap =
        div [ ClassName parent]
                [
                    div [ ClassName child] [ str "1" ]
                    div [ ClassName child] [ str "2" ]
                    div [ ClassName child] [ str "3" ]
                    div [ ClassName child] [ str "4" ]
                ]

    // Flex no wrap
    let parent =
        fss
            [
                Display Display.Flex
                Width (em 40.0)
                FlexWrap Flex.WrapReverse
            ]

    let child =
        fss
            [
                BackgroundColor (hex "#cee")
                Width (em 15.0)
                Margin (px 10)
            ]

    let wrapReverse =
        div [ ClassName parent]
                [
                    div [ ClassName child] [ str "1" ]
                    div [ ClassName child] [ str "2" ]
                    div [ ClassName child] [ str "3" ]
                    div [ ClassName child] [ str "4" ]
                ]

    // Flex flow
    let parent =
        fss
            [
                BackgroundColor Color.pink
                Margins [px 48; Margin.Auto; px 0]
                Width (px 600)
                Display Display.Flex
                FlexDirection model.FlexDirection
                FlexWrap model.FlexWrap
            ]

    let child =
        fss
            [
                BackgroundColor Color.black
                Color Color.white
                Margin (px 6)
                Width (px 120)
            ]

    let flexFlow =
        div [ ClassName parent]
                [
                    div [ ClassName child] [ str "1" ]
                    div [ ClassName child] [ str "2" ]
                    div [ ClassName child] [ str "3" ]
                    div [ ClassName child] [ str "4" ]
                    div [ ClassName child] [ str "5" ]
                    div [ ClassName child] [ str "6" ]
                    div [ ClassName child] [ str "7" ]
                ]

    // AlignContent
    let parent =
        fss
            [
                BackgroundColor (hex "ccc")
                Display Display.Flex
                FlexWrap Flex.Wrap
                Width (pct 100)
                Height (em 20.0)
                AlignContent model.AlignContent
            ]

    let child =
        fss
            [
                BackgroundColor (hex "cee")
                Margin (px 2)
                Width (pct 18)
            ]

    let alignContent =
        div [ ClassName parent]
                [
                    div [ ClassName child] [ str "1" ]
                    div [ ClassName child] [ str "2" ]
                    div [ ClassName child] [ str "3" ]
                    div [ ClassName child] [ str "4" ]
                    div [ ClassName child] [ str "5" ]
                    div [ ClassName child] [ str "6" ]
                    div [ ClassName child] [ str "7" ]
                ]

    // Flex-basis & flex grow
    let parent =
        fss
            [
                BackgroundColor (hex "ccc")
                Height (px 100)
                Display Display.Flex
                FlexDirection Flex.Row
                AlignItems Center
            ]

    let child =
        fss
            [
                Margins [px 0; px 10]
                BackgroundColor Color.white
                FlexBasis (px 120)
                FlexGrow (Flex.Grow 1.)
                Height (px 75)

            ]

    let child3 =
        fss
            [
                Margins [px 0; px 10]
                BackgroundColor Color.white
                FlexBasis (px 120)
                FlexGrow (Flex.Grow 2.)
                Height (px 75)
            ]

    let flexBasisGrow =
        div [ ClassName parent]
            [
                div [ ClassName child ] []
                div [ ClassName child ] []
                div [ ClassName child3 ] []
            ]

    // Flex-basis & flex shrink
    let parent =
        fss
            [
                BackgroundColor (hex "ccc")
                Height (px 100)
                Display Display.Flex
                FlexDirection Flex.Row
                AlignItems Center
            ]

    let child =
        fss
            [
                Margins [px 0; px 10]
                BackgroundColor Color.white
                FlexBasis (px 120)
                FlexGrow (Flex.Grow 1.)
                Height (px 75)

            ]

    let child3 =
        fss
            [
                Margins [px 0; px 10]
                BackgroundColor Color.white
                FlexBasis (px 120)
                FlexShrink (Flex.Shrink 2.)
                Height (px 75)
            ]

    let flexBasisShrink =
        div [ ClassName parent]
            [
                div [ ClassName child ] []
                div [ ClassName child ] []
                div [ ClassName child3 ] []
            ]


    let formStyle =
        fss
            [
                BorderStyle Border.Solid
                BorderWidth (px 1)
                BorderColor Color.orangeRed
                Margin (px 20)
            ]

    fragment []
        [
            p [] [ str "I am aligend with flexbox" ]
            alignment
            p [] [ str "We are evenly distributed! Just try resizing" ]
            flow
            p [] [ str "Flex direction is row!" ]
            rows
            p [] [ str "Flex direction is columns!" ]
            columns
            p [] [ str "Flex wrap is no wrap!" ]
            noWrap
            p [] [ str "Flex wrap is wrap!" ]
            wrap
            p [] [ str "Flex wrap is wrapreverse!" ]
            wrapReverse
            p [] [ str "Flex flow" ]
            div [ ClassName (fss [ Display Display.Flex ]) ]
                [
                    form [ ClassName formStyle ]
                        [
                            h3 [] [str "Flex direction" ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexDirection Flex.Row)) ]
                                    str "row"
                                ]

                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexDirection Flex.RowReverse)) ]
                                    str "row-reverse"
                                ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexDirection Flex.Column)) ]
                                    str "column"
                                ]

                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexDirection Flex.ColumnReverse)) ]
                                    str "column-reverse"
                                ]
                        ]
                    form [ ClassName formStyle ]
                        [
                            h3 [] [str "Flex wrap" ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexWrap Flex.NoWrap)) ]
                                    str "nowrap"
                                ]

                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexWrap Flex.Wrap)) ]
                                    str "wrap"
                                ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexWrap Flex.WrapReverse)) ]
                                    str "wrap-reverse"
                                ]
                        ]
                ]
            flexFlow
            p [] [ str "Align content" ]
            form [ ClassName formStyle ]
                [
                    h3 [] [str "Align content" ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent Flex.FlexStart)) ]
                            str "FlexStart"
                        ]

                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent Flex.FlexEnd)) ]
                            str "FlexEnd"
                        ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent Flex.Center)) ]
                            str "Center"
                        ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent Flex.Stretch)) ]
                            str "Stretch(default)"
                        ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent Flex.SpaceBetween)) ]
                            str "SpaceBetween"
                        ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent Flex.SpaceAround)) ]
                            str "SpaceAround"
                        ]
                ]
            alignContent
            p [] [str "Flex basis & grow" ]
            flexBasisGrow
            p [] [str "Flex basis & shrink" ]
            flexBasisShrink
        ]

let MediaQueryExamples () =
   let style =
        fss
            [
                Width (px 200)
                Height (px 200)
                BackgroundColor Color.blue
                MediaQuery
                    [ Media.MaxWidth (px 500); Media.MinWidth (px 200) ]
                    [ BackgroundColor Color.red ]

                MediaQuery
                    [ Media.MinHeight (px 700)]
                    [ BackgroundColor Color.pink]

                MediaQueryFor Media.Print
                    []
                    [
                        MarginTop (px 200)
                        Transform (Transform.Rotate(deg 45.0))
                        BackgroundColor Color.red
                    ]

                MediaQuery
                    [ Media.Orientation Media.Landscape]
                    [ Color Color.green; FontSize (px 28)]
            ]
   div [ ClassName style] [ str "foosball"]

let SelectorExamples () =
    fragment []
        [
            h2 [] [ str "Selectors" ]
            let descendant =
                fss
                    [
                        ! Html.P
                            [
                                BackgroundColor Color.red
                            ]
                    ]
            h3 [] [ str "Descendant" ]
            div [ ClassName descendant] [
                p [] [ str "Apple"]
                div [] [ p [] [str "An apple a day keeps the doctor away"]]
                p [] [ str "Banana"]
                p [] [ str "Cherry"]
            ]

            let child =
                fss
                    [
                        !> Html.P
                            [
                                BackgroundColor Color.green
                            ]
                    ]
            h3 [] [ str "Child" ]
            div [ ClassName child] [
                p [] [ str "Apple"]
                div [] [ p [] [str "An apple a day keeps the doctor away"]]
                p [] [ str "Banana"]
                p [] [ str "Cherry"]
            ]

            let adjacentSibling =
                fss
                    [
                        !+ Html.P
                            [
                                BackgroundColor Color.yellow
                            ]
                    ]
            h3 [] [ str "Adjacent Sibling" ]
            div [] [
                p [] [ str "Apple"]
                div [ ClassName adjacentSibling ] [ p [] [str "An apple a day keeps the doctor away"]]
                p [] [ str "Banana"]
                p [] [ str "Cherry"]
            ]

            let generalSibling =
                fss
                    [
                        !~ Html.P
                            [
                                BackgroundColor Color.orangeRed
                            ]
                    ]
            h3 [] [ str "General Sibling" ]
            div [] [
                p [] [ str "Apple"]
                div [ ClassName generalSibling ] [ p [] [str "An apple a day keeps the doctor away"]]
                p [] [ str "Banana"]
                p [] [ str "Cherry"]
            ]

            let composed =
                fss
                    [
                        ! Html.Div
                            [
                                !> Html.Div
                                    [
                                        !> Html.P
                                            [
                                                !+ Html.P
                                                    [
                                                        Color Color.purple
                                                        FontSize (px 25)
                                                    ]
                                            ]
                                    ]

                            ]
                    ]

            h3 [] [ str "Composed" ]
            div [ ClassName composed ]
                [
                    div []
                        [
                            div []
                                [
                                    p [] [ str "Hi" ]
                                    // Skal bli lilla og 25 px
                                    p [] [ str "Hi" ]
                                ]
                        ]
                ]
        ]

let CursorExamples () =
    let testo x =
       div
            [
                ClassName ( fss
                    [
                        Width (px 100)
                        Height (px 100)
                        BackgroundColor Color.blue
                        Cursor (Cursor.Cursor x)
                        BorderStyle Border.Style.Solid
                        BorderWidth (px 5)
                    ])
            ]
        []

    div [
        ClassName ( fss
                   [
                        Display Display.Flex
                        FlexDirection Flex.Direction.Row
                        FlexWrap Flex.Wraps.Wrap
                   ])
        ]
        [
            h2 [] [ str "Cursors" ]
            testo (Cursor.Default)
            testo (Cursor.ContextMenu)
            testo (Cursor.Help)
            testo (Cursor.Pointer)
            testo (Cursor.Progress)
            testo (Cursor.Wait)
            testo (Cursor.Cell)
            testo (Cursor.Crosshair)
            testo (Cursor.Text)
            testo (Cursor.VerticalText)
            testo (Cursor.Alias)
            testo (Cursor.Copy)
            testo (Cursor.Move)
            testo (Cursor.NoDrop)
            testo (Cursor.NotAllowed)
            testo (Cursor.AllScroll)
            testo (Cursor.ColResize)
            testo (Cursor.RowResize)
            testo (Cursor.NResize)
            testo (Cursor.EResize)
            testo (Cursor.SResize)
            testo (Cursor.WResize)
            testo (Cursor.NsResize)
            testo (Cursor.EwResize)
            testo (Cursor.NeResize)
            testo (Cursor.NwResize)
            testo (Cursor.SeResize)
            testo (Cursor.SwResize)
            testo (Cursor.NeswResize)
            testo (Cursor.NwseResize)
        ]

let PsuedoClassExamples () =
    fragment []
        [
            h2 [] [ str "Psuedo selectors" ]

            let active =
                fss
                    [
                        Active
                            [
                                Width (px 200)
                                Height (px 200)
                            ]
                    ]

            div []
                [
                    str "Active"
                    button [ ClassName active  ] [ str "Activate!" ]
                ]

            let anyLink =
                fss
                    [
                        AnyLink
                            [
                                Color Color.orangeRed
                            ]
                    ]

            div []
                [
                    str "Any link"
                    br []
                    a [ ClassName anyLink; Href "#" ] [ str "This is a link!" ]
                ]

            str "Empty"
            let empty =
                fss
                    [
                        Width (px 80)
                        Height (px 80)
                        BackgroundColor Color.pink
                        Empty
                            [
                                BackgroundColor Color.lime
                            ]
                    ]

            div [ ClassName empty ] [ str "Not empty" ]
            div [ ClassName empty ] []
            div [ ClassName empty ] [ str "Not empty" ]

            let disabled =
                fss
                    [
                        BackgroundColor Color.red
                        Disabled
                            [
                                BackgroundColor Color.blue
                            ]
                    ]

            str "Disabled is blue"
            div []
                [
                    input [ ClassName disabled ]
                    input [ ClassName disabled; HTMLAttr.Disabled true]
                ]

            let checkedStyle =
                fss
                    [
                        Checked
                            [
                                Width (px 100)
                                Height (px 100)
                            ]
                    ]

            str "Checked"
            div []
                [
                    input [ ClassName checkedStyle; Type "checkbox"; HTMLAttr.Checked true ]
                    input [ ClassName checkedStyle; Type "checkbox" ]
                ]

            let enabled =
                fss
                    [
                        BackgroundColor Color.white
                        Enabled
                            [
                                BackgroundColor Color.red
                            ]
                    ]

            str "Enabled is blue"
            div []
                [
                    input [ ClassName enabled ]
                    input [ ClassName enabled; HTMLAttr.Disabled true ]
                ]

            let firstChild =
                fss
                    [
                        FirstChild
                            [
                                BackgroundColor Color.orange
                            ]
                    ]

            str "First child"
            div []
                [
                    p [ ClassName firstChild ] [ str "Orange" ]
                    p [ ClassName firstChild ] [ str "Not orange" ]
                    p [ ClassName firstChild ] [ str "Not orange" ]
                ]

            let firstOfType =
                fss
                    [
                        FirstOfType
                            [
                                BackgroundColor Color.orange
                            ]
                    ]

            str "First of type"
            div []
                [
                    p [ ClassName firstOfType ] [ str "Orange" ]
                    p [ ClassName firstOfType ] [ str "Not orange" ]
                    p [ ClassName firstOfType ] [ str "Not orange" ]
                    span [ ClassName firstOfType ] [ str "Orange" ]
                    span [ ClassName firstOfType ] [ str "Not orange" ]
                ]

            let focus =
                fss
                    [
                        Focus
                            [
                                BackgroundColor Color.red
                            ]
                    ]

            str "Focus"
            div [ ClassName (fss [Display Display.Flex; FlexDirection Flex.Column; Width (px 100)]) ]
                [
                    input [ ClassName focus ]
                    input [ ClassName focus ]
                    input [ ClassName focus ]
                    input [ ClassName focus ]
                    input [ ClassName focus ]
                ]

            let visited =
                fss
                    [
                        Visited
                            [
                                Color Color.orangeRed
                            ]
                    ]

            str "Visited"
            div [ ClassName (fss [Display Display.Flex; FlexDirection Flex.Column; Width (px 100)]) ]
                [
                    a [ Href "#"; ClassName visited ] [ str "visited" ]
                    a [ Href "foo"; ClassName visited ] [ str "not visited" ]
                ]

            str "Invalid"

            let invalid =
                fss
                    [
                        Invalid
                            [
                                BackgroundColor Color.red
                            ]
                    ]


            div [ ClassName (fss [Display Display.Flex; FlexDirection Flex.Column; Width (px 100)]) ]
                [
                    input [ ClassName invalid ]
                    input [ ClassName invalid; HTMLAttr.Required true ]
                ]


            str "Last child"

            let LastChild =
                fss
                    [
                        LastChild
                            [
                                BackgroundColor Color.orange
                            ]
                    ]

            div []
                [
                    p [ ClassName LastChild ] [ str "Not orange" ]
                    p [ ClassName LastChild ] [ str "Not orange" ]
                    p [ ClassName LastChild ] [ str "Orange" ]
                ]

            let firstOfType =
                fss
                    [
                        LastOfType
                            [
                                BackgroundColor Color.orange
                            ]
                    ]

            str "First of type"
            div []
                [
                    p [ ClassName firstOfType ] [ str "Not orange" ]
                    p [ ClassName firstOfType ] [ str "Not orange" ]
                    span [ ClassName firstOfType ] [ str "Not orange" ]
                    span [ ClassName firstOfType ] [ str "Orange" ]
                    p [ ClassName firstOfType ] [ str "Orange" ]
                ]

            let link =
                fss
                    [
                        Link
                            [
                                Color Color.darkRed
                            ]
                    ]

            div []
                [
                    str "Link"
                    br []
                    a [ ClassName link; Href "notVisited" ] [ str "This is a link!" ]
                ]

            let nthChild =
                fss
                    [
                        NthChild("2",
                            [
                                BackgroundColor Color.orange
                            ])
                    ]

            str "Nth child 2"
            div []
                [
                    p [ ClassName nthChild ] [ str "Not orange" ]
                    p [ ClassName nthChild ] [ str "Orange" ]
                    span [ ClassName nthChild ] [ str "Not orange" ]
                    span [ ClassName nthChild ] [ str "Not orange" ]
                    p [ ClassName nthChild ] [ str "Not orange" ]
                ]

            let nthLastChild =
                fss
                    [
                        NthLastChild("2",
                            [
                                BackgroundColor Color.orange
                            ])
                    ]

            str "Nth last child 2"
            div []
                [
                    p [ ClassName nthLastChild ] [ str "Not orange" ]
                    p [ ClassName nthLastChild ] [ str "Not orange" ]
                    span [ ClassName nthLastChild ] [ str "Not orange" ]
                    span [ ClassName nthLastChild ] [ str "Orange" ]
                    p [ ClassName nthLastChild ] [ str "Not orange" ]
                ]

            let onlyChild =
                fss
                    [
                        OnlyChild
                            [
                                BackgroundColor Color.orange
                            ]
                    ]

            str "Only child"
            div []
                [
                    span [ ClassName onlyChild ] [ str "Orange" ]
                ]
            div []
                [
                    div [ ClassName onlyChild ] [ str "Not orange" ]
                    div [ ClassName onlyChild ] [ str "Not orange" ]
                ]


            let onlyOfType =
                fss
                    [
                        OnlyOfType
                            [
                                BackgroundColor Color.orange
                            ]
                    ]

            str "Only of type"
            div []
                [
                    span [ ClassName onlyOfType ] [ str "Orange" ]
                    div [ ClassName onlyOfType ] [ str "Not orange" ]
                    div [ ClassName onlyOfType ] [ str "Not orange" ]
                ]
            div []
                [
                    div [ ClassName onlyOfType ] [ str "Not orange" ]
                    div [ ClassName onlyOfType ] [ str "Not orange" ]
                ]


            str "Target"
            let target =
                fss
                    [
                        Target [
                            BackgroundColor Color.darkBlue
                        ]
                    ]

            section [ Id "section2"; ClassName target ]
                [
                    h3 [] [ str "Foo" ]
                    p [] [ str "Foofoffoo" ]
                    a [ Href "#section2" ] [ str "Go to section 2" ]
                ]
        ]

let ListStyleExamples () =
    fragment []
        [
            let listStyleImage =
                fss
                    [
                        ListStyleImage (ListStyle.Url "https://mdn.mozillademos.org/files/11981/starsolid.gif")
                    ]

            ul [ ClassName listStyleImage ]
                [
                    li [] [ str "Item 1" ]
                    li [] [ str "Item 2" ]
                ]

            let inside =
                fss
                    [
                        ListStylePosition ListStyle.Inside
                        ListStyleType ListStyle.Square
                    ]

            let outside =
                fss
                    [
                        ListStylePosition ListStyle.Outside
                        ListStyleType ListStyle.Circle
                    ]

            let insideImage =
                fss
                    [
                        ListStylePosition ListStyle.Inside
                        ListStyleImage (ListStyle.Url "https://mdn.mozillademos.org/files/11979/starsolid.gif")
                    ]

            ul [ ClassName inside ]
                [
                    str "List 1"
                    li [] [str "List Item 1-1" ]
                    li [] [str "List Item 1-2" ]
                    li [] [str "List Item 1-3" ]
                    li [] [str "List Item 1-4" ]
                ]
            ul [ ClassName outside ]
                [
                    str "List 2"
                    li [] [str "List Item 2-1" ]
                    li [] [str "List Item 2-2" ]
                    li [] [str "List Item 2-3" ]
                    li [] [str "List Item 2-4" ]
                ]
            ul [ ClassName insideImage ]
                [
                    str "List 3"
                    li [] [str "List Item 3-1" ]
                    li [] [str "List Item 3-2" ]
                    li [] [str "List Item 3-3" ]
                    li [] [str "List Item 3-4" ]
                ]
        ]

let CounterStyleExamples () =
     fragment []
                [
                    let someCounter =
                        counterStyle
                            [
                                System Cyclic
                                Symbols (Symbols.Strings [ "o"; "p" ])
                                Suffix (Suffix.String ". ")
                            ]

                    let style =
                        fss
                            [
                                Label "FOOOOOO"
                                ListStyleType (ListStyle.Custom someCounter)
                            ]

                    ul [ ClassName style ]
                        [
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                        ]

                    let fixedCounter =
                        counterStyle
                            [
                                System System.Fixed
                                Symbols (Symbols.Strings ["Ⓐ"; "Ⓑ"; "Ⓒ"; "Ⓓ"; "Ⓔ"; "Ⓕ"; "Ⓖ"; "Ⓗ"; "Ⓘ"; "Ⓙ"; "Ⓚ"; "Ⓛ"; "Ⓜ"; "Ⓝ"; "Ⓞ"; "Ⓟ"; "Ⓠ"; "Ⓡ"; "Ⓢ"; "Ⓣ"; "Ⓤ"; "Ⓥ"; "Ⓦ"; "Ⓧ"; "Ⓨ"; "Ⓩ"])
                                Suffix (Suffix.String " ")
                            ]

                    let items =
                        fss
                            [
                                ListStyleType (ListStyle.Custom fixedCounter)
                            ]

                    ul [ ClassName items ]
                        [
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                        ]
                ]

let PseudoElementExamples () =
    let required =
        fss
            [
                FontSize (em 0.8)

                Before
                    [
                        Content (Content.String "")
                        Display Display.Block
                        Width (px 10)
                        Height (px 10)
                        BackgroundColor Color.red
                    ]

                After
                    [
                        Content (Content.String "")
                        Display Display.Block
                        Width (px 10)
                        Height (px 10)
                        BackgroundColor Color.blue
                    ]

            ]

    let tooltip =
        fss
            [
                FontSize (px 25)
                Color (hex "0bd")
                Display Display.Inline
                Position Position.Relative

                Hover
                    [
                        Before
                            [
                                BorderStyle Border.Solid
                                BorderWidths [px 12; px 6; px 0; px 6]
                                BorderColor (hex "444 transparent")
                                Content (Content.String "")
                                Left (pct 45)
                                Bottom (px 30)
                                Position Position.Absolute
                            ]

                        After
                            [
                                Display Display.Flex
                                JustifyContent Flex.Center
                                BackgroundColor (hex "444")
                                BorderRadius (px 8)
                                Color (hex "fff")
                                Content (Content.Attribute Attribute.Title)
                                Margins [px -82; Auto; (px 0); (px 0)]
                                FontSize (px 16)
                                Padding (px 13)
                                Width (px 220)
                            ]
                    ]


            ]

    let firstLetter =
        fss
            [
                FirstLetter
                    [
                        FontSize (pct 130)
                    ]
            ]

    let firstLine =
        fss
            [
                FirstLine
                    [
                        Color Color.red
                    ]
            ]

    let selection =
        fss
            [
                Selection
                    [
                        BackgroundColor Color.orangeRed
                    ]
            ]


    fragment []
        [
            p [] [str "It works"]

            div []
                [
                    label [ ClassName required ] [ str "Name" ]
                    input [ Type "text"; HTMLAttr.Required true ]
                    button [ HTMLAttr.Custom("data-tooltip", "Tooltip") ] [ str "Submit form" ]
                ]

            p [] [ str "Tooltip time" ]
            a [ Title "Hello from a tooltip!"; ClassName tooltip ] [ str "Tooltip here, hover!" ]

            p [] [ str "First letter" ]
            p [ ClassName firstLetter ] [ str "FOOBAR" ]

            p [] [ str "First line" ]
            p [ ClassName firstLine ]
                [
                    str "Styles will only be applied to the first line of this paragraph. After that, all text will be styled like normal. See what I mean?"
                ]

            p [] [ str "Selection" ]
            p [ ClassName selection ]
                [
                    str "Styles will only be applied to the first line of this paragraph. After that, all text will be styled like normal. See what I mean?"
                ]
        ]
    
let GridExamples () =
    fragment []
        [
            h3 [] [str "Grid examples"]
            
            h2 [] [str "Simple grid example"]
            let container =
                fss
                    [
                        BackgroundColor (hex "eee")
                        Width (px 1000)
                        Margins [px 20; Auto]
                        Display Display.Grid
                        GridTemplateRow (Grid.Repeat(Value 2, px 150))
                        GridTemplateColumn (Grid.Repeat(Value 3, fr 1.))
                        GridGap (px 30)
                    ]
                    
            let itemTemplate =
                [
                    Padding (px 20)
                    FontSize (px 20)
                    FontFamily Font.SansSerif
                    Color (hex "fff")
                ] |> fss
                
            let item1 =
                itemTemplate @
                [
                    BackgroundColor Color.orangeRed
                    GridRow (Grid.Row (Value 2, Value 3))
                    GridColumn (Grid.Column (Value 2, Value 3))
                ] |> fss
                
            let item2 =
                itemTemplate @
                [
                    BackgroundColor Color.yellowGreen
                    GridRow (Grid.Row (Value 1, Value 2))
                ] |> fss
                
            let item3 =
                itemTemplate @
                [
                    BackgroundColor Color.blueViolet
                    GridRow (Grid.Row (Value 2, Value 3))
                    GridColumn (Grid.Column (Value 1, Value 2))
                ] |> fss
                
            let item4 =
                itemTemplate @
                [
                    BackgroundColor Color.paleVioletred
                ] |> fss
                
            let item5 =
                itemTemplate @
                [
                    BackgroundColor Color.royalBlue
                    GridRow (Grid.Row (Value 2, Value 3))
                    GridColumn (Grid.Column (Value 1, Value 2))
                ] |> fss
                
            let item6 =
                itemTemplate @
                [
                    BackgroundColor Color.goldenrod
                    GridRow (Grid.Row (Value 1, Value 2))
                    GridColumn (Grid.Column (Value 2, Value 3))
                ] |> fss
                
            div [ ClassName container ]
                [ 
                    div [ ClassName item1 ] [ str "1: Orange"]
                    div [ ClassName item2 ] [ str "2: Green"]
                    div [ ClassName item3 ] [ str "3: Violet"]
                    div [ ClassName item4 ] [ str "4: Pink"]
                    div [ ClassName item5 ] [ str "5: Blue"]
                    div [ ClassName item6 ] [ str "6: Brown"]
                ]
            
                
            str "foo"
        ]
    
let render (model: Model) (dispatch: Msg -> unit) =
    div []
        [

            //ColorExamples ()
            //BackgroundExamples model dispatch
            //FontExamples ()
            //FontFaceExamples ()
            //BorderExamples model dispatch
            //MarginExamples ()
            //PaddingExamples ()
            //TransformExamples ()
            //TransitionExamples ()
            //TextExamples ()
            //AnimationExamples ()
            //FlexBoxExamples model dispatch
            //MediaQueryExamples ()
            //SelectorExamples ()
            //CursorExamples ()
            //PsuedoClassExamples ()
            //ListStyleExamples ()
            //CounterStyleExamples ()
            //PseudoElementExamples ()
            GridExamples ()
        ]

Program.mkSimple init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run