package br.com.panteratech.eaiapp.ui.screens.main

import android.content.Context
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import br.com.panteratech.eaiapp.listeners.ApiListener
import br.com.panteratech.eaiapp.model.ChatModel
import br.com.panteratech.eaiapp.repository.local.shared.SharedCache
import br.com.panteratech.eaiapp.repository.remote.api.ChatRepository
import dagger.hilt.android.lifecycle.HiltViewModel
import dagger.hilt.android.qualifiers.ApplicationContext
import javax.inject.Inject

@HiltViewModel
class MainViewModel @Inject constructor(
    var api: ChatRepository,
    @ApplicationContext private var context: Context
) : ViewModel() {
    private val mChats = MutableLiveData<List<ChatModel>>()
    val chats: LiveData<List<ChatModel>> by lazy {
        mChats
    }

    fun getChats() {
        val listener = object : ApiListener<ChatModel>{
            override fun onSuccess(t: ChatModel): ChatModel {
                TODO("Not yet implemented")
            }

            override fun onSuccess(t: List<ChatModel>){
                mChats.value = t
            }

            override fun onError(t: String) {
                TODO("Not yet implemented")
            }
        }

        val token = SharedCache.getAccessToken(context)

        token?.let { api.getChats(listener, "Bearer $it") }
    }
}