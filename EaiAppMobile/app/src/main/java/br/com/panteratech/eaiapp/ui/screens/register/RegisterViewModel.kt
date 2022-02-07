package br.com.panteratech.eaiapp.ui.screens.register

import androidx.lifecycle.ViewModel
import br.com.panteratech.eaiapp.model.RegisterModel
import br.com.panteratech.eaiapp.repository.remote.api.UserRepository
import dagger.hilt.android.lifecycle.HiltViewModel
import javax.inject.Inject

@HiltViewModel
class RegisterViewModel @Inject constructor(
     var api : UserRepository
): ViewModel() {

    fun register(model: RegisterModel){
        api.registerUser(model);
    }
}