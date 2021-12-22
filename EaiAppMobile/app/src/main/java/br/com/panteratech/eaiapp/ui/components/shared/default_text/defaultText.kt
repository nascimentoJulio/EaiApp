package br.com.panteratech.eaiapp.ui.components.shared.default_text

import androidx.compose.material.MaterialTheme
import androidx.compose.material.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.graphics.Color

import androidx.compose.ui.unit.sp

@Composable
fun DefaultText(
    text: String = "Hello, World!",
    color: Color = MaterialTheme.colors.onSurface,
    fontSize: Float = 14f
) {
    Text(
        text = text,
        style = MaterialTheme.typography.body1,
        color = color,
        fontSize = fontSize.sp,
    )
}