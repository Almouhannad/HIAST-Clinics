export class JWTHandler {

    //#region JWT Decoder
    public static decodeJWT(jwt: string) {
        const payload = jwt.split('.')[1];
        const decodedPayload = atob(payload);
        const textDecoder = new TextDecoder('utf-8');
        const claimsJson = JSON.parse(
            textDecoder.decode(
                new Uint8Array(
                    decodedPayload.split('').map(c => c.charCodeAt(0))
                )
            )
        );
        return claimsJson;
    }
    //#endregion

    //#region Sotre JWT in a cookie
    public static storeJWT(jwt: string): void {
        const claims = this.decodeJWT(jwt);
        const expiresAt = claims.exp * 1000; // convert seconds to milliseconds
        const cookieOptions = {
            expires: new Date(expiresAt),
            path: '/'
        };
        let cookieString = `jwt=${jwt};`;
        if (cookieOptions.expires) {
            cookieString += `expires=${cookieOptions.expires.toUTCString()};`;
        }
        if (cookieOptions.path) {
            cookieString += `path=${cookieOptions.path};`;
        }
        document.cookie = cookieString;
    }
    //#endregion

    //#region Get JWT from cookie
    public static getJwtFromCookie(): string | null {
        const cookieString = document.cookie;
        const cookiePairs = cookieString.split(';');
        for (const cookie of cookiePairs) {
            const [key, value] = cookie.trim().split('=');
            if (key === 'jwt') {
                return value
            }
        }
        return null;
    }
    //#endregion

    //#region Delete JWT cookie
    public static deleteJwtCookie(): void {
        document.cookie = 'jwt=; expires=Thu, 01 Jan 1970 00:00:00 GMT;';
    }
    //#endregion
}