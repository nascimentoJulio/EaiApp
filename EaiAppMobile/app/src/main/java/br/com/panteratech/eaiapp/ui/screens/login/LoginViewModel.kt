package br.com.panteratech.eaiapp.ui.screens.login

import android.content.Context
import android.util.Log
import android.widget.Toast
import androidx.lifecycle.ViewModel
import br.com.panteratech.eaiapp.listeners.ApiListener
import br.com.panteratech.eaiapp.model.LoginModel
import br.com.panteratech.eaiapp.repository.local.shared.SharedCache
import br.com.panteratech.eaiapp.repository.remote.api.UserRepository
import br.com.panteratech.eaiapp.response.LoginResponse
import dagger.hilt.android.lifecycle.HiltViewModel
import dagger.hilt.android.qualifiers.ApplicationContext
import javax.inject.Inject

@HiltViewModel
class LoginViewModel @Inject constructor(
    var api: UserRepository,
    @ApplicationContext private var context: Context
) : ViewModel() {

    fun login(loginModel: LoginModel) : Boolean{
        val apiListener = object : ApiListener<LoginResponse> {
            override fun onSuccess(t: LoginResponse): LoginResponse {
                SharedCache.setAccessToken(context, t.accessToken)
                val token = SharedCache.getAccessToken(context)
                token?.let { Log.i("token", it) }

                return t
            }

            override fun onError(t: String) {
                Toast.makeText(context, t, Toast.LENGTH_SHORT).show()
            }

        }
        return api.login(loginModel, apiListener)
    }
}