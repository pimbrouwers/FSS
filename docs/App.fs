﻿module App

open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Fable.Core.JsInterop

open Fss.Main
open Fss.Color
open Fss.Units
open Fss.Fonts
open Fss.Border.BorderStyle
open Fss.Border.BorderWidth

type Model =
    { Message : string}

type Msg =
    | NoMessage

let init() =
    { Message = "Hello" }

let update (msg: Msg) (model: Model): Model =
    match msg with
    | NoMessage -> model

let Color =
    fragment []
        [
            h1 [] [ str "Color" ]
            p [] [ str "Tons of different ways to style color" ]
            p [ ClassName (fss [Color deeppink]) ] [ str "Named colors like deeppink"]
            p [ ClassName (fss [Color (rgb 255 0 0)])] [ str "Or you can style it using an RGB function!"]
            p [ ClassName (fss [Color (rgba 0 0 0 0.5)])] [ str "We also support RGBA"]
            p [ ClassName (fss [Color (hex "00ff00")])] [ str "or you can use HEX"]
            p [ ClassName (fss [Color (hex "0000ff80")])] [ str "HEX can also be transparent"]
            p [ ClassName (fss [Color (hsl 120 0.5 0.5)])] [ str "Or just use HSL"]
            p [ ClassName (fss [Color (hsla 120 0.5 0.5 0.5)])] [ str "HSL can also be transparent"]
        ]

let Fonts =
    fragment []
        [
            h1 [] [ str "fonts" ]
            h2 [] [ str "font-size"]
            p [ClassName (fss [FontSize XxSmall])] [ str "Fonts can be xx-Small" ]
            p [ClassName (fss [FontSize XSmall])] [ str "Fonts can be x-Small" ]
            p [ClassName (fss [FontSize Small])] [ str "Fonts can be small" ]
            p [ClassName (fss [FontSize Medium])] [ str "Fonts can be medium" ]
            p [ClassName (fss [FontSize Large])] [ str "Fonts can be large" ]
            p [ClassName (fss [FontSize XLarge])] [ str "Fonts can be x-large" ]
            p [ClassName (fss [FontSize XxLarge])] [ str "Fonts can be xx-large" ]
            p [ClassName (fss [FontSize XxxLarge])] [ str "Fonts can be xxx-large" ]
            p [ClassName (fss [FontSize Smaller])] [ str "Fonts can be smaller" ]
            p [ClassName (fss [FontSize Larger])] [ str "Fonts can be larger" ]

            p [ClassName (fss [FontSize (px 28)])] [ str "Fonts can be set with pixels" ]
            p [ClassName (fss [FontSize (pct 300)])] [ str "Fonts can be set with percent" ]
            p [ClassName (fss [FontSize (em 2.5)])] [ str "Fonts can be set with ems" ]
            p [ClassName (fss [FontSize (rem 3.0)])] [ str "Fonts can be set with rems" ]
            p [ClassName (fss [FontSize (cm 3.3)])] [ str "Fonts can be set with cm" ]
            p [ClassName (fss [FontSize (mm 33.3)])] [ str "Fonts can be set with mm" ]
            p [] [ str "and more!"]
        ]

let Border =
    fragment []
        [
            h1 [] [ str "borders"]
            h2 [] [ str "Set unique borders"]
            p [ ClassName (fss [BorderStyle [Solid]])] [ str "I have a solid border" ]
            p [ ClassName (fss [BorderStyle [Double]])] [ str "I have a double border"]
            p [ ClassName (fss [BorderStyle [Groove]])] [ str "I have a groove border"]
            p [ ClassName (fss [BorderStyle [Inset]])] [ str "I have an inset border"]
            p [ ClassName (fss [BorderStyle [Ridge]])] [ str "I have a ridge border"]
            p [ ClassName (fss [BorderStyle [Dashed]])] [ str "I have a dashed border"]
            p [ ClassName (fss [BorderStyle [Dotted]])] [ str "I have a dotted border"]
            p [ ClassName (fss [BorderStyle [Outset]])] [ str "I have an outset border"]
            p [ ClassName (fss [BorderStyle [Hidden]])] [ str "I have a hidden border"]
            p [ ClassName (fss [BorderStyle [None]])] [ str "I don't have a border"]
            p [ ClassName (fss [BorderStyle [Groove; Dotted; Solid; Dashed]])] [ str "I have a mixed border"]
            p [] [ str "We can also apply only border width" ]
            p [ ClassName (fss 
                    [
                        BorderWidth [Thin]
                        BorderStyle [Solid]
                    ])] [ str "I have a thin border" ]
            p [ ClassName (fss 
                    [
                        BorderWidth [(px 3)]
                        BorderStyle [Solid]
                    ])] [ str "I have a 3px border" ]
            p [ ClassName (fss 
                    [
                        BorderWidth [(px 3); (px 4); (px 5); (px 6)]
                        BorderStyle [Solid]
                    ])] [ str "I have a mixed width border" ]
            p [ ClassName (fss [Border [Thick; Double; green]])] [ str "Border shorthand also works" ]
        ]

let render (model: Model) (dispatch: Msg -> unit) =
    div []
        [
            Color
            Fonts
            Border
        ]

Program.mkSimple init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run
