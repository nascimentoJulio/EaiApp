package br.com.panteratech.eaiapp.ui.components.shared.input

import androidx.compose.foundation.layout.width
import androidx.compose.material.MaterialTheme
import androidx.compose.material.OutlinedTextField
import androidx.compose.material.Text
import androidx.compose.material.TextFieldDefaults
import androidx.compose.runtime.*
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.input.PasswordVisualTransformation
import androidx.compose.ui.text.input.VisualTransformation
import androidx.compose.ui.unit.dp

@Composable
fun InputDefault(
    focusedBorderColor: Color = MaterialTheme.colors.onBackground,
    unfocusedBorderColor: Color = MaterialTheme.colors.secondary,
    placeholder: String,
    trailingIcon: @Composable (() -> Unit)? = null,
    visualTransformation: VisualTransformation = VisualTransformation.None,
    label: String
) {
    var text by remember { mutableStateOf("") }

    OutlinedTextField(
        value = text,
        modifier = Modifier.width(330.dp),
        placeholder = { Text(text = placeholder) },
        label = { Text(label) },
        onValueChange = { newText -> text = newText },
        trailingIcon = trailingIcon,
        visualTransformation = visualTransformation,
        colors = TextFieldDefaults.outlinedTextFieldColors(
            focusedBorderColor = focusedBorderColor,
            unfocusedBorderColor = unfocusedBorderColor,
            cursorColor = focusedBorderColor,
            placeholderColor = MaterialTheme.colors.secondaryVariant,
            unfocusedLabelColor = MaterialTheme.colors.primary
        ),
    )
}