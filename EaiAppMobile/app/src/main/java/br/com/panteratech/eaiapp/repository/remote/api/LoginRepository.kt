package br.com.panteratech.eaiapp.repository.remote.api

import android.content.Context
import br.com.panteratech.eaiapp.listeners.ApiListener
import br.com.panteratech.eaiapp.model.LoginModel
import br.com.panteratech.eaiapp.response.LoginResponse
import dagger.hilt.android.qualifiers.ApplicationContext
import javax.inject.Inject

class LoginRepository @Inject constructor(
    private var eaiApi: EaiApi,
): BaseRepository<LoginResponse>(){

    fun login(apiListener: ApiListener<LoginResponse>, loginModel: LoginModel){
        val call = eaiApi.login(loginModel)
        callApi(apiListener, call)
    }
}