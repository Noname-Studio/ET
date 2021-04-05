using System;
using System.Runtime.InteropServices;
using AOT;

public class IOSAuth 
{
    // Add a using for: AOT
    // Add a using for: System.Runtime.InteropServices

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void IdentityVerificationSignatureCallback(
    string publicKeyUrl, 
    IntPtr signaturePointer, int signatureLength,
    IntPtr saltPointer, int saltLength,
    ulong timestamp,
    string error);

    [DllImport("__Internal")]
    private static extern void generateIdentityVerificationSignature(
    [MarshalAs(UnmanagedType.FunctionPtr)]IdentityVerificationSignatureCallback callback);

    // Note: This callback has to be static because Unity's il2Cpp doesn't support marshalling instance methods.
    [MonoPInvokeCallback(typeof(IdentityVerificationSignatureCallback))]
    private static void OnIdentityVerificationSignatureGenerated(
    string publicKeyUrl, 
    IntPtr signaturePointer, int signatureLength,
    IntPtr saltPointer, int saltLength,
    ulong timestamp,
    string error)
    {
        // Create a managed array for the signature
        var signature = new byte[signatureLength];
        Marshal.Copy(signaturePointer, signature, 0, signatureLength);

        // Create a managed array for the salt
        var salt = new byte[saltLength];
        Marshal.Copy(saltPointer, salt, 0, saltLength);

        UnityEngine.Debug.Log($"publicKeyUrl: {publicKeyUrl}");
        UnityEngine.Debug.Log($"signature: {signature.Length}");
        UnityEngine.Debug.Log($"salt: {salt.Length}");
        UnityEngine.Debug.Log($"timestamp: {timestamp}");
        UnityEngine.Debug.Log($"error: {error}");
    }
}
