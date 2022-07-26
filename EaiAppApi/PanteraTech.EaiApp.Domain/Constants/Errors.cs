namespace PanteraTech.EaiApp.Domain.Constanst
{
  public class Errors
  {
    public static string INVALID_FIELD = "InvalideField";

    public static string INVALID_FIELD_MESSAGE = "Campo '{0}' invalido. {1}";

    public static string USER_NOT_FOUND = "UserNotFound";

    public static string USER_NOT_FOUND_MESSAGE = "Usuario ou senha incorretos!";

    public static string HAS_USER = "HasUser";

    public static string HAS_USER_MESSAGE = "Usuario já cadastrado na base.";

    public static string SAME_USER = "SameUser";

    public static string SAME_USER_MESSAGE = "Os usuarios deve ser diferentes";
    
    public static string LIMIT_EXCEEDED = "LimitExceeded";

    public static string LIMIT_EXCEEDED_MESSAGE = "O limite foi excedido. Limite maximo: {0}";

    public static string INTERNAL_ERROR = "InternalError";

    public const string INTERNAL_ERROR_MESSAGE = "Erro interno, tente novamente";

    }
}