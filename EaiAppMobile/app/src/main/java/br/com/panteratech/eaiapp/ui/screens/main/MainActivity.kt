package br.com.panteratech.eaiapp.ui.screens.main

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.Image
import androidx.compose.foundation.layout.Column
import androidx.compose.material.MaterialTheme
import androidx.compose.material.Surface
import androidx.compose.runtime.livedata.observeAsState
import androidx.compose.material.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.hilt.navigation.compose.hiltViewModel
import androidx.lifecycle.LiveData
import br.com.panteratech.eaiapp.model.ChatModel
import br.com.panteratech.eaiapp.ui.theme.EaiAppTheme
import coil.compose.rememberImagePainter

class MainActivity() : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        setContent {
            EaiAppTheme {
                Surface(color = MaterialTheme.colors.background) {

                    MainScreen()
                }
            }
        }
    }
}

@Composable
fun MainScreen() {
    val viewModel = hiltViewModel<MainViewModel>()
    viewModel.getChats()

    val chatLiveData = viewModel.chats

    val chats by chatLiveData.observeAsState()
    val s = chats
    chats?.forEach { it -> Column() {
        Text(text = it.usernameFriend)
        Image(
            painter = rememberImagePainter(data = it.friendProfileUrl,
                builder = {
                    crossfade(true)
                }),
            contentDescription = null,
        )
    } }

}

