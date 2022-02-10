package br.com.panteratech.eaiapp.modules

import android.content.Context
import br.com.panteratech.eaiapp.repository.remote.api.ChatRepository
import br.com.panteratech.eaiapp.repository.remote.api.EaiApi
import br.com.panteratech.eaiapp.repository.remote.api.UserRepository
import dagger.Module
import dagger.Provides
import dagger.hilt.InstallIn
import dagger.hilt.android.qualifiers.ApplicationContext
import dagger.hilt.components.SingletonComponent
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import javax.inject.Singleton

@Module
@InstallIn(SingletonComponent::class)
object AppModule {

    @Singleton
    @Provides
    fun createClient() : EaiApi {
        return Retrofit.Builder()
            .baseUrl("https://eai-app-back.herokuapp.com")
            .addConverterFactory(GsonConverterFactory.create())
            .build()
            .create(EaiApi::class.java)
    }

    @Singleton
    @Provides
    fun createRepositoryUser(
         eaiApi: EaiApi,
         @ApplicationContext context: Context
    ) : UserRepository{
        return UserRepository(eaiApi, context)
    }

    @Singleton
    @Provides
    fun createRepositoryChat(
        eaiApi: EaiApi,
        @ApplicationContext context: Context
    ) : ChatRepository{
        return ChatRepository(eaiApi, context)
    }




}