package br.com.panteratech.eaiapp.repository.remote.api

import android.content.Context
import br.com.panteratech.eaiapp.model.RegisterModel
import dagger.hilt.android.qualifiers.ApplicationContext

import javax.inject.Inject


class RegisterUserRepository @Inject constructor(
    private var eaiApi: EaiApi,
    @ApplicationContext private var context: Context
) : BaseRepository<Long>(){
    fun registerUser(registerModel: RegisterModel) {
        val call = eaiApi.registerUser(registerModel)
        callApi(null, call)
    }

}