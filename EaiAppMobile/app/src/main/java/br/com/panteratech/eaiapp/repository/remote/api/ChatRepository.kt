package br.com.panteratech.eaiapp.repository.remote.api

import android.content.Context
import br.com.panteratech.eaiapp.listeners.ApiListener
import br.com.panteratech.eaiapp.model.ChatModel
import dagger.hilt.android.qualifiers.ApplicationContext
import retrofit2.Call
import javax.inject.Inject
import retrofit2.Callback
import retrofit2.Response


class ChatRepository @Inject constructor(
    private var eaiApi: EaiApi,
    @ApplicationContext private var context: Context
) {

    fun getChats(listener: ApiListener<ChatModel>, token: String) {

        val call = eaiApi.getChats(token)
        call.enqueue(object : Callback<List<ChatModel>> {
            override fun onResponse(
                call: Call<List<ChatModel>>,
                response: Response<List<ChatModel>>
            ) {
                if (response.code() == 200){
                    response.body()?.let { listener.onSuccess(it) }
                }
            }

            override fun onFailure(call: Call<List<ChatModel>>, t: Throwable) {
                val s = ""
            }

        })

    }
}

