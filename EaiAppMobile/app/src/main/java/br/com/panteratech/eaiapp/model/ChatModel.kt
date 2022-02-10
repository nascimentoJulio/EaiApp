package br.com.panteratech.eaiapp.model

data class ChatModel(
    val friendProfileUrl: String,
    val hourLastMessage: String,
    val id: Int,
    val lastMessage: String,
    val quantityNoreadMessages: String,
    val usernameFriend: String
)