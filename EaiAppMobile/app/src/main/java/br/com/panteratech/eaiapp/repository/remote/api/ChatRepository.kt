package br.com.panteratech.eaiapp.repository.remote.api

import br.com.panteratech.eaiapp.listeners.ApiListener
import br.com.panteratech.eaiapp.model.BaseModel
import br.com.panteratech.eaiapp.model.ChatModel
import javax.inject.Inject


class ChatRepository @Inject constructor(
    private var eaiApi: EaiApi,
) : BaseRepository<ChatModel>() {

    fun getChats(listener: ApiListener<ChatModel>, token: String) {
        val call = eaiApi.getChats(token)
        callApiList(listener, call)
    }
}


