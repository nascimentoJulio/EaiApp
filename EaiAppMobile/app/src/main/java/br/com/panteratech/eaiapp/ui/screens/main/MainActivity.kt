package br.com.panteratech.eaiapp.ui.screens.main

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.itemsIndexed
import androidx.compose.material.ExperimentalMaterialApi
import androidx.compose.material.MaterialTheme
import androidx.compose.material.Surface
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.livedata.observeAsState
import androidx.hilt.navigation.compose.hiltViewModel
import br.com.panteratech.eaiapp.ui.components.activity.main.FriendItem
import br.com.panteratech.eaiapp.ui.components.shared.container.Container
import br.com.panteratech.eaiapp.ui.theme.EaiAppTheme

class MainActivity() : ComponentActivity() {
    @ExperimentalMaterialApi
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

@ExperimentalMaterialApi
@Composable
fun MainScreen() {

    val viewModel = hiltViewModel<MainViewModel>()
    viewModel.getChats()

    val chatLiveData = viewModel.chats

    val chats by chatLiveData.observeAsState()

    Container {
        LazyColumn() {
            chats?.let {
                itemsIndexed(it) { _, chat ->
                    FriendItem(chatModel = chat)
                }
            }
        }
    }
}

