package br.com.panteratech.eaiapp.ui.screens.login

import android.content.Context
import android.widget.Toast
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import br.com.panteratech.eaiapp.listeners.ApiListener
import br.com.panteratech.eaiapp.model.LoginModel
import br.com.panteratech.eaiapp.model.ValidateTokenModel
import br.com.panteratech.eaiapp.repository.local.shared.SharedCache
import br.com.panteratech.eaiapp.repository.remote.api.LoginRepository
import br.com.panteratech.eaiapp.repository.remote.api.ValidateTokenRepository
import br.com.panteratech.eaiapp.response.LoginResponse
import dagger.hilt.android.lifecycle.HiltViewModel
import dagger.hilt.android.qualifiers.ApplicationContext
import javax.inject.Inject

@HiltViewModel
class LoginViewModel @Inject constructor(
    var loginApi: LoginRepository,
    var validateTokenApi: ValidateTokenRepository,
    @ApplicationContext private var context: Context
) : ViewModel() {

    private val mIsValidToken = MutableLiveData<Boolean>()
    val isValidToken: LiveData<Boolean> by lazy {
        mSuccessLogin
    }

    private val mSuccessLogin = MutableLiveData<Boolean>()
    val isSuccessLogin: LiveData<Boolean> by lazy {
        mSuccessLogin
    }

    fun login(loginModel: LoginModel) {
        val apiListener = object : ApiListener<LoginResponse> {
            override fun onSuccess(t: LoginResponse): LoginResponse {
                SharedCache.setAccessToken(context, t.accessToken)
                mSuccessLogin.value = true
                return t
            }

            override fun onError(t: String) {
                Toast.makeText(context, t, Toast.LENGTH_SHORT).show()
            }

            override fun onSuccess(t: List<LoginResponse>) {
                TODO("Not yet implemented")
            }

        }
        loginApi.login(apiListener, loginModel)
    }

    fun validateToken() {
        val listener = object : ApiListener<ValidateTokenModel> {
            override fun onSuccess(t: ValidateTokenModel): ValidateTokenModel {
                mSuccessLogin.value = t.isValid
                return t
            }

            override fun onSuccess(t: List<ValidateTokenModel>) {
                val s = ""
            }

            override fun onError(message: String) {
                val s = ""
            }

        }

        val token = SharedCache.getAccessToken(context)

        token?.let { validateTokenApi.validateToken(listener, "Bearer $it") }
    }
}