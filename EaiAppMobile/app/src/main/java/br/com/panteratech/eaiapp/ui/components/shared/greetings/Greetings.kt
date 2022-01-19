package br.com.panteratech.eaiapp.ui.components.shared.greetings

import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.width
import androidx.compose.material.MaterialTheme
import androidx.compose.material.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp

@Composable
fun Greeting(message: String) {
    Column(
        Modifier.width(200.dp)
    ) {
        Text(
            text = message,
            style = MaterialTheme.typography.h1,
            fontSize = 18.sp,
        )
    }
}