package br.com.panteratech.eaiapp.ui.theme

import androidx.compose.foundation.isSystemInDarkTheme
import androidx.compose.material.Colors
import androidx.compose.material.MaterialTheme
import androidx.compose.runtime.Composable
import androidx.compose.ui.graphics.Color

private val colorsPallet = Colors(
    primary = ButtonsBackGround,
    primaryVariant = ButtonBarFocus,
    secondary = InputColor,
    background = Background,
    surface = Titles,
    onPrimary = BottomBar,
    onSecondary = ButtonBarFocus,
    onBackground = ShadowInputFocus,
    onSurface = Color.White,
    error =  Color.Red,
    isLight = true,
    onError = Color.Red,
    secondaryVariant = PlaceHolderColor

)

@Composable
fun EaiAppTheme(darkTheme: Boolean = isSystemInDarkTheme(), content: @Composable() () -> Unit) {
    MaterialTheme(
        colors = colorsPallet,
        typography = Typography,
        shapes = Shapes,
        content = content
    )
}