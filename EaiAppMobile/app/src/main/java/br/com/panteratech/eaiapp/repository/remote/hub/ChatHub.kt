package br.com.panteratech.eaiapp.repository.remote.api

import android.util.Log
import br.com.panteratech.eaiapp.model.MessageModel
import com.microsoft.signalr.HubConnectionBuilder

class ChatHub {
    private val connection = HubConnectionBuilder.create("").build()

    fun sendMessage(message: MessageModel) {
        connection.invoke(MessageModel::class.java, METHODS.SendMessages.name, message)
    }

    fun getMessage() : MessageModel{
        connection.on("ReceiveMessage", { loggedUser, message, recipient ->
            Log.i("WebSocket", "$loggedUser, $message, $recipient" )
        },
            String::class.java, String::class.java,String::class.java )

        return MessageModel(1)
    }

    enum class METHODS {
        SendMessages
    }
}

