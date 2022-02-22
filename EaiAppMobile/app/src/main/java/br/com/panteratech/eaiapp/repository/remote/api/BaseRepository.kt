package br.com.panteratech.eaiapp.repository.remote.api

import android.util.Log
import br.com.panteratech.eaiapp.listeners.ApiListener
import br.com.panteratech.eaiapp.repository.constants.HttpStatusCode
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

open class BaseRepository<TModel> {

    fun callApi(listener: ApiListener<TModel>?, call: Call<TModel>) {
        call.enqueue(object : Callback<TModel> {
            override fun onResponse(call: Call<TModel>, response: Response<TModel>) {
                when (response.code()) {
                    HttpStatusCode.OK,
                    HttpStatusCode.NO_CONTENT -> response.body()?.let { listener?.onSuccess(it) }
                    HttpStatusCode.CREATED -> true
                    else -> response.body()?.let { listener?.onError(it.toString()) }
                }
            }
            override fun onFailure(call: Call<TModel>, t: Throwable) {
                Log.i("Internal error", "Erro ao chamar api: ${t.localizedMessage}")
            }

        })
    }

    fun callApiList(listener: ApiListener<TModel>?, call: Call<List<TModel>>) {
        call.enqueue(object : Callback<List<TModel>> {
            override fun onResponse(call: Call<List<TModel>>, response: Response<List<TModel>>) {

                when (response.code()) {
                    HttpStatusCode.OK,
                    HttpStatusCode.NO_CONTENT -> response.body()?.let { listener?.onSuccess(it) }
                    HttpStatusCode.CREATED -> true
                    else -> response.body()?.let { listener?.onError(it.first().toString()) }
                }
            }

            override fun onFailure(call: Call<List<TModel>>, t: Throwable) {
                Log.i("Internal error", "Erro ao chamar api: ${t.localizedMessage}")
            }
        })
    }
}