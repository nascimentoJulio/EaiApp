package br.com.panteratech.eaiapp.repository.local.shared

import android.content.Context
import br.com.panteratech.eaiapp.R

class SharedCache {


    companion object {

        fun getAccessToken(context: Context): String? {
            val sharedPreferences = context.getSharedPreferences(
                context.getString(R.string.access_token),
                Context.MODE_PRIVATE
            )
            return sharedPreferences.getString(context.getString(R.string.access_token), "")
        }

        fun setAccessToken(context: Context, token: String) {
            val sharedPreferences = context.getSharedPreferences(
                context.getString(R.string.access_token),
                Context.MODE_PRIVATE
            )
            sharedPreferences.edit().putString(
                context.getString(R.string.access_token),
                token
            ).apply()
        }
    }
}