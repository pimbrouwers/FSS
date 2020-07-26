﻿namespace Fss

open Fable.Core
open Fable.Core.JsInterop

open Utilities.Types
open Utilities.Global
open Property
open Color
open Units.Size
open Units.Angle
open Fonts
open BorderStyle
open BorderWidth
open Animation
open Transform
open Transition
open Display
open FlexDirection
open JustifyContent
open AlignItems
open FlexWrap
open AlignContent
open AlignSelf
open Order
open FlexGrow
open FlexShrink
open FlexBasis
open Margin
open Selector

open Browser

module Value = 
    [<Import("css", from="emotion")>]
    let private css(x) = jsNative
    let css' x = css(x) 

    let value (v: ICSSProperty): string =
        match v with
            | :? Property as n       -> Property.value n
            | :? Transition as t     -> Transition.value t
            | _ -> "Unknown CSS"

    type CSSProperty =
        | Selector of Selector * CSSProperty list

        | Label of string

        | Color of IColor

        | BackgroundColor of IColor

        | Hover of CSSProperty list

        | FontSize of IFontSize

        | BorderStyle       of IBorderStyle
        | BorderStyles      of IBorderStyle list
        | BorderWidth       of IBorderWidth
        | BorderWidths      of IBorderWidth list
        | BorderTopWidth    of IBorderWidth
        | BorderRightWidth  of IBorderWidth
        | BorderBottomWidth of IBorderWidth
        | BorderLeftWidth   of IBorderWidth

        | BorderRadius              of Size
        | BorderRadiuses            of Size list
        | BorderTopLeftRadius       of Size
        | BorderTopLeftRadiuses     of Size list
        | BorderTopRightRadius      of Size
        | BorderTopRightRadiuses    of Size list
        | BorderBottomRightRadius   of Size
        | BorderBottomRightRadiuses of Size list
        | BorderBottomLeftRadius    of Size
        | BorderBottomLeftRadiuses  of Size list

        | BorderColor       of IColor 
        | BorderColors      of IColor list
        | BorderTopColor    of IColor
        | BorderRightColor  of IColor 
        | BorderBottomColor of IColor
        | BorderLeftColor   of IColor

        | Width       of Size
        | Height      of Size
        | Perspective of Size

        | Display        of IDisplay
        | FlexDirection  of IFlexDirection
        | FlexWrap       of IFlexWrap
        | JustifyContent of IJustifyContent
        | AlignItems     of IAlignItems
        | AlignContent   of IAlignContent
        | Order          of IOrder
        | FlexGrow       of IFlexGrow
        | FlexShrink     of IFlexShrink
        | FlexBasis      of IFlexBasis
        | AlignSelf      of IAlignSelf

        | MarginTop    of IMargin
        | MarginRight  of IMargin
        | MarginBottom of IMargin
        | MarginLeft   of IMargin
        | Margin       of IMargin 
        | Margins      of IMargin list

        | Animation                of IAnimation list  
        | Animations               of IAnimation list list
        | AnimationName            of IAnimation
        | AnimationNames           of IAnimation list
        | AnimationDuration        of Time
        | AnimationDurations       of Time list
        | AnimationTimingFunction  of Timing
        | AnimationTimingFunctions of Timing list
        | AnimationDelay           of Time
        | AnimationDelays          of Time list
        | AnimationIterationCount  of IterationCount
        | AnimationIterationCounts of IterationCount list
        | AnimationDirection       of Direction
        | AnimationDirections      of Direction list
        | AnimationFillMode        of FillMode
        | AnimationFillModes       of FillMode list
        | AnimationPlayState       of PlayState
        | AnimationPlayStates      of PlayState list

        | Transform  of ITransform
        | Transforms of ITransform list

        | Transition of ICSSProperty
        | Transitions of ICSSProperty list
        | TransitionDelay of ICSSProperty
        | TransitionDuration of ICSSProperty
        | TransitionProperty of ICSSProperty
        | TransitionTimingFunction of ICSSProperty

    let combineWs (list: 'a list) (value: 'a -> string) = combineList list value " "
    let combineComma (list: 'a list) (value: 'a -> string) = combineList list value ", " 
    let combineAnimationNames (list: IAnimation list): string = list |> List.map string |> String.concat ", "
    let combineAnimations (list: IAnimation list list): string = combineComma list (fun a -> combineWs a Animation.value)

    let rec createCSSObject (attributeList: CSSProperty list) = 
        attributeList
        |> List.map (
            function
                | Selector (s, ss)   -> Selector.value s               ==> createCSSObject ss

                | Label l            -> Property.value label           ==> l
                
                | Color c            -> Property.value color           ==> Color.value c
                
                | BackgroundColor bc -> Property.value backgroundColor ==> Color.value bc
                
                | Hover h            -> Property.value hover           ==> createCSSObject h
                
                | FontSize f         -> Property.value fontSize        ==> Fonts.value f

                | BorderStyle  bs  -> Property.value borderStyle ==> BorderStyle.value bs
                | BorderStyles bss -> Property.value borderStyle ==> combineWs bss BorderStyle.value

                | BorderWidth       bw  -> Property.value borderWidth       ==> BorderWidth.value bw
                | BorderWidths      bws -> Property.value borderWidth       ==> combineWs bws BorderWidth.value
                | BorderTopWidth    bw  -> Property.value borderTopWidth    ==> BorderWidth.value bw
                | BorderRightWidth  bw  -> Property.value borderRightWidth  ==> BorderWidth.value bw
                | BorderBottomWidth bw  -> Property.value borderBottomWidth ==> BorderWidth.value bw
                | BorderLeftWidth   bw  -> Property.value borderLeftWidth   ==> BorderWidth.value bw
               
                | BorderRadius              br -> Property.value borderRadius            ==> Units.Size.value br
                | BorderRadiuses            br -> Property.value borderRadius            ==> combineWs br Units.Size.value
                | BorderTopLeftRadius       br -> Property.value borderTopLeftRadius     ==> Units.Size.value br
                | BorderTopLeftRadiuses     br -> Property.value borderTopLeftRadius     ==> combineWs br Units.Size.value
                | BorderTopRightRadius      br -> Property.value borderTopRightRadius    ==> Units.Size.value br
                | BorderTopRightRadiuses    br -> Property.value borderTopRightRadius    ==> combineWs br Units.Size.value
                | BorderBottomRightRadius   br -> Property.value borderBottomRightRadius ==> Units.Size.value br
                | BorderBottomRightRadiuses br -> Property.value borderBottomRightRadius ==> combineWs br Units.Size.value
                | BorderBottomLeftRadius    br -> Property.value borderBottomLeftRadius  ==> Units.Size.value br
                | BorderBottomLeftRadiuses  br -> Property.value borderBottomLeftRadius  ==> combineWs br Units.Size.value

                | BorderColor       bc  -> Property.value borderColor       ==> Color.value bc
                | BorderColors      bcs -> Property.value borderColor       ==> combineWs bcs Color.value
                | BorderTopColor    bc  -> Property.value borderTopColor    ==> Color.value bc
                | BorderRightColor  bc  -> Property.value borderRightColor  ==> Color.value bc
                | BorderBottomColor bc  -> Property.value borderBottomColor ==> Color.value bc
                | BorderLeftColor   bc  -> Property.value borderLeftColor   ==> Color.value bc

                | Width       w -> Property.value width       ==> Units.Size.value w
                | Height      h -> Property.value height      ==> Units.Size.value h
                | Perspective p -> Property.value perspective ==> Units.Size.value p

                | Display        d -> Property.value display        ==> Display.value d
                | FlexDirection  f -> Property.value flexDirection  ==> FlexDirection.value f
                | FlexWrap       f -> Property.value flexWrap       ==> FlexWrap.value f
                | FlexBasis      f -> Property.value flexBasis      ==> FlexBasis.value f
                | JustifyContent j -> Property.value justifyContent ==> JustifyContent.value j
                | AlignItems     a -> Property.value alignItems     ==> AlignItems.value a
                | AlignContent   a -> Property.value alignContent   ==> AlignContent.value a
                | Order          o -> Property.value order          ==> Order.value o
                | FlexGrow       f -> Property.value flexGrow       ==> FlexGrow.value f
                | FlexShrink     f -> Property.value flexShrink     ==> FlexShrink.value f
                | AlignSelf      a -> Property.value alignSelf      ==> AlignSelf.value a

                | MarginTop    m  -> Property.value marginTop    ==> Margin.value m
                | MarginRight  m  -> Property.value marginRight  ==> Margin.value m
                | MarginBottom m  -> Property.value marginBottom ==> Margin.value m
                | MarginLeft   m  -> Property.value marginLeft   ==> Margin.value m
                | Margin       m  -> Property.value margin       ==> Margin.value m
                | Margins      ms -> Property.value margin       ==> combineWs ms Margin.value

                | Animation                a   -> Property.value animation               ==> combineWs a Animation.value
                | Animations               ans -> Property.value animation               ==> combineAnimations ans
                | AnimationName            n   -> Property.value animationName           ==> string n
                | AnimationNames           ns  -> Property.value animationName           ==> combineAnimationNames ns
                | AnimationDuration        d   -> Property.value animationDuration       ==> Animation.value d
                | AnimationDurations       ds  -> Property.value animationDuration       ==> combineComma ds Animation.value
                | AnimationTimingFunction  t   -> Property.value animationTimingFunction ==> Animation.value t
                | AnimationTimingFunctions ts  -> Property.value animationTimingFunction ==> combineComma ts Animation.value
                | AnimationDelay           d   -> Property.value animationDelay          ==> Animation.value d
                | AnimationDelays          ds  -> Property.value animationDelay          ==> combineComma ds Animation.value
                | AnimationIterationCount  i   -> Property.value animationIterationCount ==> Animation.value i
                | AnimationIterationCounts is  -> Property.value animationIterationCount ==> combineComma is Animation.value
                | AnimationDirection       d   -> Property.value animationDirection      ==> Animation.value d
                | AnimationDirections      ds  -> Property.value animationDirection      ==> combineComma ds Animation.value
                | AnimationFillMode        f   -> Property.value animationFillMode       ==> Animation.value f
                | AnimationFillModes       fs  -> Property.value animationFillMode       ==> combineComma fs Animation.value
                | AnimationPlayState       p   -> Property.value animationPlayState      ==> Animation.value p
                | AnimationPlayStates      ps  -> Property.value animationPlayState      ==> combineComma ps Animation.value

                | Transform  t  -> Property.value transform ==> Transform.value t
                | Transforms ts -> Property.value transform ==> combineWs ts Transform.value

                | Transition               t  -> Property.value transition               ==> value t
                | Transitions              ts -> Property.value transition               ==> combineComma ts value
                | TransitionDelay          t  -> Property.value transitionDelay          ==> value t
                | TransitionDuration       t  -> Property.value transitionDuration       ==> value t
                | TransitionProperty       t  -> Property.value transitionProperty       ==> value t
                | TransitionTimingFunction t  -> Property.value transitionTimingFunction ==> value t
        )
        |> createObj