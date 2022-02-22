package br.com.panteratech.eaiapp.repository.remote.api

import android.content.Context
import android.widget.Toast
import br.com.panteratech.eaiapp.R
import br.com.panteratech.eaiapp.listeners.ApiListener
import br.com.panteratech.eaiapp.model.LoginModel
import br.com.panteratech.eaiapp.model.RegisterModel
import br.com.panteratech.eaiapp.response.LoginResponse
import dagger.hilt.android.qualifiers.ApplicationContext
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import javax.inject.Inject


class RegisterUserRepository @Inject constructor(
    private var eaiApi: EaiApi,
    @ApplicationContext private var context: Context
) {
    fun registerUser(registerModel: RegisterModel) {
        val call = eaiApi.registerUser(registerModel)
        call.enqueue(object : Callback<Long> {
            override fun onResponse(call: Call<Long>, response: Response<Long>) {
                if (response.code() == 200){
                    Toast.makeText(context, R.string.succes_register, Toast.LENGTH_SHORT).show()
                }
            }

            override fun onFailure(call: Call<Long>, t: Throwable) {
                var s = ""
            }

        })
    }

}