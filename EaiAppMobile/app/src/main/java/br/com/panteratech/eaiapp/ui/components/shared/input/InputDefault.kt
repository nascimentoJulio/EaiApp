package br.com.panteratech.eaiapp.ui.components.shared.input

import androidx.compose.ui.graphics.Color
import androidx.compose.material.MaterialTheme
import androidx.compose.material.OutlinedTextField
import androidx.compose.material.Text
import androidx.compose.material.TextFieldDefaults
import androidx.compose.runtime.*

@Composable
fun InputDefault(
    focusedBorderColor: Color = MaterialTheme.colors.onBackground,
    unfocusedBorderColor: Color = MaterialTheme.colors.secondary,
    label: String
) {
    var text by remember { mutableStateOf("") }

    OutlinedTextField(
        value = text,
        label = { Text(label) },
        onValueChange = { newText -> text = newText },
        colors = TextFieldDefaults.outlinedTextFieldColors(
            focusedBorderColor = focusedBorderColor,
            unfocusedBorderColor = unfocusedBorderColor
        )

    )
}