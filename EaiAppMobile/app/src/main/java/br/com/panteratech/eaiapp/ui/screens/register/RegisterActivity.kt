package br.com.panteratech.eaiapp.ui.screens.register

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.*
import androidx.compose.material.*
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.res.stringResource
import androidx.compose.ui.text.input.PasswordVisualTransformation
import androidx.compose.ui.text.input.VisualTransformation
import androidx.compose.ui.unit.dp
import br.com.panteratech.eaiapp.R
import br.com.panteratech.eaiapp.ui.components.shared.button.ButtonDefault
import br.com.panteratech.eaiapp.ui.components.shared.checkbox.CheckboxDefault
import br.com.panteratech.eaiapp.ui.components.shared.container.Container
import br.com.panteratech.eaiapp.ui.components.shared.default_text.DefaultText
import br.com.panteratech.eaiapp.ui.components.shared.greetings.Greeting
import br.com.panteratech.eaiapp.ui.components.shared.input.InputDefault
import br.com.panteratech.eaiapp.ui.theme.EaiAppTheme

class RegisterActivity : ComponentActivity() {
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
        ) {
            Greeting(stringResource(id = R.string.register_greeting))
            FormContainer()
        }
    }
}

@Composable
private fun FormContainer() {
    var isShowPassword by remember { mutableStateOf(false) }

    Column(
        horizontalAlignment = Alignment.CenterHorizontally,
        modifier = Modifier.fillMaxWidth()
    ) {
        Spacer(modifier = Modifier.padding(top = 60.dp))

        InputDefault(
            label = stringResource(id = R.string.name),
            placeholder = stringResource(id = R.string.inform_your_name)
        )

        Spacer(modifier = Modifier.padding(top = 45.dp))

        InputDefault(
            label = stringResource(id = R.string.email),
            placeholder = stringResource(id = R.string.inform_your_email)
        )

        Spacer(modifier = Modifier.padding(top = 45.dp))

        InputDefault(
            label = stringResource(id = R.string.password),
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

        CheckboxDefault()


        Spacer(modifier = Modifier.padding(top = 150.dp))

        ButtonDefault(text = stringResource(id = R.string.register), onClick = null)
    }
}