# TextAnimation
ITweenみたいにアニメーションさせたり色を変えたりできるやつ

Hashの書き方

``` C#
//ReScale
        TextAnimationHash res1 = new TextAnimationHash (
            new TextAnimationRescale (),
            new TextAnimationTime (0.2f),
            new TextAnimationVecMax (new Vector3 (5f, 5f, 5f)),
            new TextAnimationVecMin (new Vector3 (1f, 1f, 1f))
        );
//Roll(回転)
        TextAnimationHash rol1 = new TextAnimationHash (
            new TextAnimationRoll (),
            new TextAnimationTime (0.2f),
            new TextAnimationAngle (180f)
        );
//Move
        TextAnimationHash m1 = new TextAnimationHash (
            new TextAnimationMove (),
            new TextAnimationTime (0.5f),
            new TextAnimationVecMax (new Vector3 (5f, 5f, 0f))
        );
//色変え
        TextAnimationHash c1 = new TextAnimationHash (
            new TextAnimationColorChange (),
            new TextAnimationTime (0.5f),
            new TextAnimationName ("_Color"),
            new TextAnimationColor (new Color (0f, 0f, 0f, 0.5f))
        );

```


実行方法

``` C#
StartCoroutine (TextAnimator.PlayLoop (new TextAnimator (GameObject, Hash)));
```
