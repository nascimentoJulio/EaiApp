package br.com.panteratech.eaiapp.ui.screens.register

import android.graphics.Bitmap
import androidx.lifecycle.ViewModel
import br.com.panteratech.eaiapp.model.RegisterModel
import br.com.panteratech.eaiapp.repository.remote.api.ImagesBucket
import br.com.panteratech.eaiapp.repository.remote.api.RegisterUserRepository
import dagger.hilt.android.lifecycle.HiltViewModel
import javax.inject.Inject

@HiltViewModel
class RegisterViewModel @Inject constructor(
    var api: RegisterUserRepository
) : ViewModel() {

    fun register(model: RegisterModel, image: Bitmap) {
        val bucket = ImagesBucket()
        val urlImage = bucket.uploadPhoto(image, model.email)
        model.urlImage = urlImage
        api.registerUser(model)
    }
}