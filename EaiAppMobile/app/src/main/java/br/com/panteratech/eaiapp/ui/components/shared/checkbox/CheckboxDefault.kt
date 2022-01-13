package br.com.panteratech.eaiapp.ui.components.shared.checkbox

import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.width
import androidx.compose.material.Checkbox
import androidx.compose.material.CheckboxDefaults
import androidx.compose.material.MaterialTheme
import androidx.compose.runtime.*
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.stringResource
import androidx.compose.ui.unit.dp
import br.com.panteratech.eaiapp.R
import br.com.panteratech.eaiapp.ui.components.shared.default_text.DefaultText

@Composable
fun CheckboxDefault(){
    var isChecked by remember { mutableStateOf(false) }

    Row(
        modifier = Modifier.width(330.dp),
        horizontalArrangement = Arrangement.Start
    ) {
        Checkbox(
            checked = isChecked,
            onCheckedChange = { isChecked = it},
            colors = CheckboxDefaults.colors(
                checkedColor = MaterialTheme.colors.primary,
                uncheckedColor = MaterialTheme.colors.primary,
                checkmarkColor = Color.White
            )
        )
        DefaultText(
            text = stringResource(id = R.string.accept_terms),
            color = MaterialTheme.colors.surface
        )
    }
}