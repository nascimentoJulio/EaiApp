package br.com.panteratech.eaiapp.ui.components.shared.badge

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.width
import androidx.compose.material.ExperimentalMaterialApi
import androidx.compose.material.MaterialTheme
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.unit.dp
import br.com.panteratech.eaiapp.ui.components.shared.default_text.DefaultText

@ExperimentalMaterialApi
@Composable
fun Badge(count: Int) {
    Row(
       modifier = Modifier
          .width(30.dp)
          .height(15.dp)
          .clip(MaterialTheme.shapes.medium)
          .background(MaterialTheme.colors.primaryVariant),
       horizontalArrangement = Arrangement.Center,
       verticalAlignment = Alignment.CenterVertically
    ) {
       DefaultText(text = count.toString(), fontSize = 12f)
    }
}