package br.com.panteratech.eaiapp.repository.remote.api

import br.com.panteratech.eaiapp.model.ChatModel
import br.com.panteratech.eaiapp.model.LoginModel
import br.com.panteratech.eaiapp.model.RegisterModel
import br.com.panteratech.eaiapp.response.LoginResponse
import retrofit2.Call
import retrofit2.http.*

interface EaiApi {

    @POST("/register")
    fun registerUser(
        @Body registerModel: RegisterModel
    ) : Call<Long>

    @POST("/login")
    fun login(
        @Body loginModel: LoginModel
    ) : Call<LoginResponse>

    @GET("/chats")
    fun getChats(
        @Header( "Authorization") authorization : String
    ) : Call<List<ChatModel>>
}