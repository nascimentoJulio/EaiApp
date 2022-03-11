package br.com.panteratech.eaiapp.repository.remote.api

import br.com.panteratech.eaiapp.listeners.ApiListener
import br.com.panteratech.eaiapp.model.ValidateTokenModel
import javax.inject.Inject

class ValidateTokenRepository @Inject constructor(
    private var eaiApi: EaiApi,
) : BaseRepository<ValidateTokenModel>() {

    fun validateToken(listener: ApiListener<ValidateTokenModel>, token: String){
        val call = eaiApi.validateToken(token)
        callApi(listener, call)
    }
}