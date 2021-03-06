package br.com.panteratech.eaiapp.ui.components.shared.button

import androidx.compose.foundation.background
import androidx.compose.foundation.border
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.width
import androidx.compose.material.*
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.compose.ui.graphics.Color
import br.com.panteratech.eaiapp.ui.components.shared.default_text.DefaultText

@Composable
fun ButtonDefault(
    text: String,
    textColor: Color = MaterialTheme.colors.onSurface,
    buttonBackground: Color = MaterialTheme.colors.primary,
    onClick: (() -> Unit)?,
    width: Float = 330f,
    height: Float = 55f,
    fontSize: Float = 18f
) {
    Button(
        onClick = { onClick?.invoke() },
        modifier = Modifier
            .width(width.dp)
            .height(height.dp),
        colors = ButtonDefaults.buttonColors(backgroundColor = buttonBackground)
    ) {
        DefaultText(
            text = text,
            color = textColor,
            fontSize = fontSize
        )
    }
}