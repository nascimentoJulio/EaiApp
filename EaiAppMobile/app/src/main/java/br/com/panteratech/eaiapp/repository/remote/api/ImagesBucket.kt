package br.com.panteratech.eaiapp.repository.remote.api

import android.graphics.Bitmap
import android.util.Log
import com.google.firebase.ktx.Firebase
import com.google.firebase.storage.StorageReference
import com.google.firebase.storage.ktx.storage
import java.io.ByteArrayOutputStream
import kotlin.math.log

class ImagesBucket {


    private val storage = Firebase.storage("gs://eai-app-b9880.appspot.com")

    fun uploadPhoto(bitmap: Bitmap?, imageName: String) : String {
        val storage = createRef("user: $imageName")

        val baos = ByteArrayOutputStream()
        bitmap?.compress(Bitmap.CompressFormat.JPEG, 100, baos)

        val data = baos.toByteArray()

        val uploadTask = storage.putBytes(data)
        var urlDownload = ""

        val urlTask = uploadTask.continueWithTask { task ->
            if (!task.isSuccessful) {
                task.exception?.let {
                    throw it
                }
            }
            storage.downloadUrl
        }.addOnCompleteListener { task ->
            if (task.isSuccessful) {
                urlDownload = task.result.toString()
            }
        }

        return urlDownload ?: "https://firebasestorage.googleapis.com/v0/b/eai-app-b9880.appspot.com/o/default%20image.png?alt=media&token=c24d4df5-b349-4430-809e-5be0df1d1de8"
    }


    private fun createRef(pathString: String): StorageReference {
        val storageReference = storage.reference

        val photoReference = storageReference.child("$pathString.jpg")

        val imagesReference = photoReference.child("profile/$pathString.jpg")

        return imagesReference
    }
}
