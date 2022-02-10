package br.com.panteratech.eaiapp.ui.screens.register

import android.app.Activity
import android.graphics.Bitmap
import android.graphics.ImageDecoder
import android.net.Uri
import android.os.Build
import android.os.Bundle
import android.provider.MediaStore
import androidx.activity.ComponentActivity
import androidx.activity.compose.rememberLauncherForActivityResult
import androidx.activity.compose.setContent
import androidx.activity.result.contract.ActivityResultContracts
import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.verticalScroll
import androidx.compose.material.*
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.graphics.asImageBitmap
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.res.stringResource
import androidx.compose.ui.text.input.PasswordVisualTransformation
import androidx.compose.ui.text.input.VisualTransformation
import androidx.compose.ui.unit.dp
import androidx.hilt.navigation.compose.hiltViewModel
import br.com.panteratech.eaiapp.R
import br.com.panteratech.eaiapp.model.RegisterModel
import br.com.panteratech.eaiapp.ui.components.shared.button.ButtonDefault
import br.com.panteratech.eaiapp.ui.components.shared.checkbox.CheckboxDefault
import br.com.panteratech.eaiapp.ui.components.shared.container.Container
import br.com.panteratech.eaiapp.ui.components.shared.default_text.DefaultText
import br.com.panteratech.eaiapp.ui.components.shared.greetings.Greeting
import br.com.panteratech.eaiapp.ui.components.shared.input.InputDefault
import br.com.panteratech.eaiapp.ui.theme.EaiAppTheme
import dagger.hilt.android.AndroidEntryPoint

@AndroidEntryPoint
class RegisterActivity() : ComponentActivity() {


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        setContent {
            EaiAppTheme {
                Surface(
                    color = MaterialTheme.colors.background,
                    content = {
                        RegisterScreen()
                    })
            }
        }
    }


}


@Composable
fun RegisterScreen() {
    Container {
        Column(
            modifier = Modifier
                .background(MaterialTheme.colors.background)
                .verticalScroll(rememberScrollState())
        ) {
            Greeting(stringResource(id = R.string.register_greeting))
            FormContainer()
        }
    }
}


@Composable
private fun FormContainer() {


    var isShowPassword by remember { mutableStateOf(false) }
    var username by remember { mutableStateOf("") }
    var email by remember { mutableStateOf("") }
    var password by remember { mutableStateOf("") }

    Column(
        horizontalAlignment = Alignment.CenterHorizontally,
        modifier = Modifier
            .fillMaxWidth()
    ) {
        Spacer(modifier = Modifier.padding(top = 45.dp))

       val bitmap = requestContentPermission()

        Spacer(modifier = Modifier.padding(top = 16.dp))

        InputDefault(
            label = stringResource(id = R.string.name),
            placeholder = stringResource(id = R.string.inform_your_name),
            onChange = { username = it }
        )

        Spacer(modifier = Modifier.padding(top = 45.dp))

        InputDefault(
            label = stringResource(id = R.string.email),
            placeholder = stringResource(id = R.string.inform_your_email),
            onChange = { email = it }
        )

        Spacer(modifier = Modifier.padding(top = 45.dp))

        InputDefault(
            label = stringResource(id = R.string.password),
            placeholder = stringResource(id = R.string.inform_your_password),
            onChange = { password = it },
            visualTransformation = if (isShowPassword) VisualTransformation.None else PasswordVisualTransformation(),
            trailingIcon = {
                IconButton(
                    onClick =
                    {
                        isShowPassword = !isShowPassword
                    }) {
                    when (isShowPassword) {
                        false -> Icon(
                            painter = painterResource(id = R.drawable.ic_show_password),
                            contentDescription = stringResource(id = R.string.show_password),
                            tint = Color.Black
                        )
                        true -> Icon(
                            painter = painterResource(id = R.drawable.ic_visibility_off),
                            contentDescription = stringResource(id = R.string.show_password),
                            tint = Color.Black
                        )
                    }
                }
            }
        )
        Spacer(modifier = Modifier.padding(top = 24.dp))

        CheckboxDefault()


        Spacer(modifier = Modifier.padding(top = 85.dp))

        val viewModel = hiltViewModel<RegisterViewModel>()


        ButtonDefault(text = stringResource(id = R.string.register), onClick = {
            bitmap?.let {
                viewModel.register(
                    RegisterModel(
                        username = username,
                        email = email,
                        password = password
                    ),
                    image = it
                )
            }

        })

        Spacer(modifier = Modifier.padding(top = 24.dp))
    }
}


@Composable
fun requestContentPermission() : Bitmap? {
    var imageUri by remember {
        mutableStateOf<Uri?>(null)
    }
    val context = LocalContext.current
    val bitmap = remember {
        mutableStateOf<Bitmap?>(null)
    }

    val launcher = rememberLauncherForActivityResult(
        contract =
        ActivityResultContracts.GetContent()
    ) { uri: Uri? ->
        imageUri = uri
    }
    Column() {
        Button(
            modifier = Modifier
                .width(150.dp)
                .height(150.dp),
            shape = RoundedCornerShape(100),
            onClick = {
                launcher.launch("image/*")
            }) {
            if (bitmap.value !== null) {
                Image(
                    bitmap = bitmap.value!!.asImageBitmap(),
                    contentDescription = null,
                    modifier = Modifier
                        .height(150.dp)
                        .width(150.dp)
                )
            } else {
                DefaultText(text = stringResource(id = R.string.take_picture))
            }
        }
    }


    Spacer(modifier = Modifier.height(12.dp))

    imageUri?.let {
        if (Build.VERSION.SDK_INT < 28) {
            bitmap.value = MediaStore.Images
                .Media.getBitmap(context.contentResolver, it)

        } else {
            val source = ImageDecoder
                .createSource(context.contentResolver, it)
            bitmap.value = ImageDecoder.decodeBitmap(source)
        }


    }
 return bitmap.value
}
