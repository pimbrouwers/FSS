namespace FssTypes

[<RequireQualifiedAccess>]
module Animation =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-direction
    type AnimationDirection =
        | Reverse
        | Alternate
        | AlternateReverse
        interface IAnimationDirection
    type AnimationFillMode =
        | Forwards
        | Backwards
        | Both
        interface IAnimationFillMode

    type IterationCount =
        | Infinite
        interface IAnimationIterationCount

    type AnimationPlayState =
        | Running
        | Paused
        interface IAnimationPlayState

    let iterationCountToString (iterationCount: IAnimationIterationCount) =
        match iterationCount with
        | :? IterationCount as i -> "infinite"
        | :? Global.CssInt as i -> GlobalValue.int i
        | _ -> "Unknown animation iteration count"