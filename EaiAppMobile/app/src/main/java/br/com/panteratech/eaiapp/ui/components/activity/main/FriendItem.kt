package br.com.panteratech.eaiapp.ui.components.activity.main

import androidx.compose.foundation.Image
import androidx.compose.foundation.layout.*
import androidx.compose.material.Divider
import androidx.compose.material.ExperimentalMaterialApi
import androidx.compose.material.MaterialTheme
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.unit.dp
import br.com.panteratech.eaiapp.R
import br.com.panteratech.eaiapp.model.ChatModel
import br.com.panteratech.eaiapp.ui.components.shared.badge.Badge
import br.com.panteratech.eaiapp.ui.components.shared.default_text.DefaultText
import coil.compose.rememberImagePainter

@ExperimentalMaterialApi
@Composable
fun FriendItem(chatModel: ChatModel) {
    val context = LocalContext.current

    Column {


        Row(
            modifier = Modifier
                .fillMaxWidth()
                .padding(8.dp)
        ) {
            Image(
                modifier = Modifier
                    .width(75.dp)
                    .height(75.dp)
                    .clip(MaterialTheme.shapes.large),
                painter = rememberImagePainter(data = chatModel.friendProfileUrl,
                    builder = {
                        crossfade(true)
                    }),
                contentDescription = context.getString(R.string.profile_picture)
            )
            Row(
                modifier = Modifier
                    .fillMaxWidth()
                    .padding(10.dp),
                horizontalArrangement = Arrangement.SpaceBetween,
                verticalAlignment = Alignment.CenterVertically
            ) {
                Column(modifier = Modifier.padding(10.dp)) {
                    DefaultText(text = chatModel.usernameFriend, color = Color.Black)
                    DefaultText(text = "Bora ali com os guri", color = Color.Black, fontSize = 12f)
                }
                Column(modifier = Modifier.padding(10.dp)) {
                    DefaultText(text = "19:00", color = Color.Black, fontSize = 12f)
                    Badge(count = 2)
                }
            }
        }
        Divider(color = Color.Black)
    }
}