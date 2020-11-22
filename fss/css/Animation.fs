namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Animations/Using_CSS_animations
module AnimationType =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-direction
    type AnimationDirectionType =
        | Reverse
        | Alternate
        | AlternateReverse
        interface IAnimationDirection
    type AnimationFillModeType =
        | Forwards
        | Backwards
        | Both
        interface IAnimationFillMode

    type IterationCountType =
        | Infinite
        interface IAnimationIterationCount

    type AnimationPlayStateType =
        | Running
        | Paused
        interface IAnimationPlayState

    let iterationCountToString (iterationCount: IAnimationIterationCount) =
        match iterationCount with
        | :? IterationCountType as i -> "infinite"
        | :? Global.CssInt as i -> GlobalValue.int i
        | _ -> "Unknown animation iteration count"

[<AutoOpen>]
module Animation =
    open AnimationType

    let private animationDirectionToString (direction: IAnimationDirection) =
        let stringifyAnimationDirection =
            function
                | Reverse -> "reverse"
                | Alternate -> "alternate"
                | AlternateReverse -> "alternate-reverse"

        match direction with
            | :? AnimationDirectionType as d -> stringifyAnimationDirection d
            | :? Keywords as k -> GlobalValue.keywords k
            | :? Normal -> GlobalValue.normal
            | _ -> "Unknown animation direction"

    let private animationFillModeToString (fillMode: IAnimationFillMode) =
        let stringifyFillMode =
            function
                | Forwards -> "forwards"
                | Backwards -> "backwards"
                | Both -> "both"

        match fillMode with
            | :? AnimationFillModeType as a -> stringifyFillMode a
            | :? None -> GlobalValue.none
            | _ -> "Unknown fill mode"

    let private playStateTypeToString (playState: IAnimationPlayState) =
        let stringifyPlayState =
            function
                | Running -> "running"
                | Paused -> "paused"

        match playState with
        | :? AnimationPlayStateType as a -> stringifyPlayState a
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown animation play state"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-delay
    type AnimationDelay =
        static member Value (delay: Units.Time.Time) = PropertyValue.cssValue Property.AnimationDelay (Units.Time.value delay)

    let AnimationDelay' (delay: Units.Time.Time) = AnimationDelay.Value(delay)

    let private directionCssValue value = PropertyValue.cssValue Property.AnimationDirection value
    let private directionCssValue' value =
        value
        |> animationDirectionToString
        |> directionCssValue
    type AnimationDirection =
        static member value (direction: IAnimationDirection) = direction |> directionCssValue'
        static member Reverse = Reverse |> directionCssValue'
        static member Alternate = Alternate |> directionCssValue'
        static member AlternateReverse = AlternateReverse |> directionCssValue'

        static member Normal = Normal |> directionCssValue'
        static member Inherit = Inherit |>  directionCssValue'
        static member Initial = Initial |> directionCssValue'
        static member Unset = Unset |> directionCssValue'

    let AnimationDirection' (direction: IAnimationDirection) = direction |> directionCssValue'

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-duration
    let private animationDurationCssValue value = PropertyValue.cssValue Property.AnimationDuration value
    type AnimationDuration =
        static member Value (duration: Units.Time.Time) = animationDurationCssValue (Units.Time.value duration)
        static member Values (durations: Units.Time.Time list) =
            durations
            |> Utilities.Helpers.combineComma Units.Time.value
            |> animationDurationCssValue

    let AnimationDuration' (duration: Units.Time.Time) = AnimationDuration.Value(duration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-fill-mode
    let private fillModeCssValue value = PropertyValue.cssValue Property.AnimationFillMode value
    let private fillModeCssValue' value =
        value
        |> animationFillModeToString
        |> fillModeCssValue
    type AnimationFillMode =
        static member Value (fillMode: IAnimationFillMode) = fillMode |> fillModeCssValue'
        static member Forwards = Forwards |> fillModeCssValue'
        static member Backwards = Backwards |> fillModeCssValue'
        static member Both = Both |> fillModeCssValue'
        static member None = None |> fillModeCssValue'

    let AnimationFillMode' (fillMode: IAnimationFillMode) = fillMode |> AnimationFillMode.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-iteration-count
    let private iterationCountCssValue value = PropertyValue.cssValue Property.AnimationIterationCount value
    let private iterationCountCssValue' value =
        value
        |> iterationCountToString
        |> iterationCountCssValue

    type AnimationIterationCount =
        static member Value (count: IAnimationIterationCount) = count |> iterationCountCssValue'
        static member Values (values: IAnimationIterationCount list) =
            values
            |> Utilities.Helpers.combineComma iterationCountToString
            |> iterationCountCssValue
        static member Infinite = Infinite |> iterationCountToString |> iterationCountCssValue

    let AnimationIterationCount' (iterationCount: IAnimationIterationCount) = AnimationIterationCount.Value iterationCount
    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-name
    let private nameToString (name: IAnimationName) =
        match name with
        | :? CssString as s -> GlobalValue.string s
        | :? None -> GlobalValue.none
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown animation name"

    let private nameValue value = PropertyValue.cssValue Property.AnimationName value
    let private nameValue' value =
        value
        |> nameToString
        |> nameValue

    type AnimationName =
        static member Name (name: IAnimationName) = name |> nameValue'
        static member Names (names: IAnimationName list) = Utilities.Helpers.combineComma nameToString names |> nameValue
        static member None = None |> nameValue'
        static member Inherit = Inherit |> nameValue'
        static member Initial = Initial |> nameValue'
        static member Unset = Unset |> nameValue'

    let AnimationName' (name: IAnimationName) = AnimationName.Name(name)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-play-state
    let private playStateCssValue value = PropertyValue.cssValue Property.AnimationPlayState value
    let private playStateCssValue' value =
        value
        |> playStateTypeToString
        |> playStateCssValue
    type AnimationPlayState =
        static member Value (playState: IAnimationPlayState) = playState |> playStateCssValue'
        static member Running = Running |> playStateCssValue'
        static member Paused = Paused |> playStateCssValue'
        static member Inherit = Inherit |> playStateCssValue'
        static member Initial = Initial |> playStateCssValue'
        static member Unset = Unset |> playStateCssValue'

    let AnimationPlayState' (playState: IAnimationPlayState) = playState |> AnimationPlayState.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-timing-function
    let private timingFunctionCssValue value = PropertyValue.cssValue Property.AnimationTimingFunction value
    let private timingFunctionCssValue' value =
        value
        |> TimingFunctionType.timingToString
        |> timingFunctionCssValue
    type AnimationTimingFunction =
        static member Value (timingFunction: TimingFunctionType.TimingType) = timingFunction |> TimingFunctionType.timingToString
        static member Values (timings: TimingFunctionType.TimingType list) = timingFunctionCssValue <| Utilities.Helpers.combineComma TimingFunctionType.timingToString timings
        static member Ease = TimingFunction.TimingFunction.Ease |> timingFunctionCssValue
        static member EaseIn = TimingFunction.TimingFunction.EaseIn |> timingFunctionCssValue
        static member EaseOut = TimingFunction.TimingFunction.EaseOut |> timingFunctionCssValue
        static member EaseInOut = TimingFunction.TimingFunction.EaseInOut |> timingFunctionCssValue
        static member Linear = TimingFunction.TimingFunction.Linear |> timingFunctionCssValue
        static member StepStart = TimingFunction.TimingFunction.StepStart |> timingFunctionCssValue
        static member StepEnd = TimingFunction.TimingFunction.StepEnd |> timingFunctionCssValue
        static member CubicBezier (p1: float, p2:float, p3:float, p4:float) =
            TimingFunction.TimingFunction.CubicBezier(p1,p2,p3,p4) |> timingFunctionCssValue
        static member Step (steps: int) = TimingFunction.TimingFunction.Step(steps) |> timingFunctionCssValue
        static member Step (steps: int, jumpTerm: TimingFunctionType.StepType) =
            TimingFunction.TimingFunction.Step(steps, jumpTerm) |> timingFunctionCssValue
        static member Inherit = Inherit |> timingFunctionCssValue'
        static member Initial = Initial |> timingFunctionCssValue'
        static member Unset = Unset |> timingFunctionCssValue'

    let AnimationTimingFunction' (timing: TimingFunctionType.TimingType) = AnimationTimingFunction.Value(timing)
