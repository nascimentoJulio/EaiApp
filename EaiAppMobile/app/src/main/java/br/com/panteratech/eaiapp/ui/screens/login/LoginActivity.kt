package br.com.panteratech.eaiapp.ui.screens.login

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
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.text.ClickableText
import androidx.compose.material.*
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.graphics.asImageBitmap
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.res.stringResource
import androidx.compose.ui.text.AnnotatedString
import androidx.compose.ui.text.TextStyle
import androidx.compose.ui.text.input.PasswordVisualTransformation
import androidx.compose.ui.text.input.VisualTransformation
import androidx.compose.ui.unit.dp
import androidx.hilt.navigation.compose.hiltViewModel
import androidx.navigation.NavHostController
import br.com.panteratech.eaiapp.R
import br.com.panteratech.eaiapp.model.LoginModel
import br.com.panteratech.eaiapp.ui.components.shared.button.ButtonDefault
import br.com.panteratech.eaiapp.ui.components.shared.container.Container
import br.com.panteratech.eaiapp.ui.components.shared.default_text.DefaultText
import br.com.panteratech.eaiapp.ui.components.shared.greetings.Greeting
import br.com.panteratech.eaiapp.ui.components.shared.input.InputDefault
import br.com.panteratech.eaiapp.ui.theme.EaiAppTheme
import br.com.panteratech.eaiapp.ui.utils.NavConfig
import dagger.hilt.android.AndroidEntryPoint

@AndroidEntryPoint
class LoginActivity : ComponentActivity() {


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {

            EaiAppTheme {
                Surface(color = MaterialTheme.colors.background) {
                    NavConfig()
                }
            }
        }
    }
}


@Composable
fun LoginContainer(navController: NavHostController) {
    Container {
        Column {
            Greeting(stringResource(id = R.string.login_greeting))
            FormContainer(navController)
        }
    }
}

@Composable
private fun FormContainer(navController: NavHostController) {
    var isShowPassword by remember { mutableStateOf(false) }
    var email by remember { mutableStateOf("") }
    var password by remember { mutableStateOf("") }
    Column(
        horizontalAlignment = Alignment.CenterHorizontally,
        modifier = Modifier.fillMaxWidth()
    ) {
        Spacer(modifier = Modifier.padding(top = 60.dp))

        InputDefault(
            label = stringResource(id = R.string.email),
            placeholder = stringResource(id = R.string.inform_your_email),
            onChange = { email = it }
        )

        Spacer(modifier = Modifier.padding(top = 45.dp))

        InputDefault(
            label = stringResource(id = R.string.password),
            onChange = { password = it },
            placeholder = stringResource(id = R.string.inform_your_password),
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

        Spacer(modifier = Modifier.padding(top = 10.dp))
        Row {
            DefaultText(
                text = stringResource(id = R.string.dont_have_an_account),
                color = Color.Black
            )
            Spacer(modifier = Modifier.padding(horizontal = 4.dp))
            ClickableText(
                onClick = {
                    navController.navigate("register")
                },
                text = AnnotatedString(text = stringResource(id = R.string.create_here)),
                style = TextStyle(
                    color = MaterialTheme.colors.primary,
                    fontFamily = MaterialTheme.typography.body1.fontFamily
                )
            )
        }
        Spacer(modifier = Modifier.padding(top = 150.dp))

        val viewModel = hiltViewModel<LoginViewModel>()


        ButtonDefault(text = stringResource(id = R.string.login), onClick = {
            val success = viewModel.login(
                LoginModel(email, password)
            )
            navController.navigate("home")
        })
    }
}
