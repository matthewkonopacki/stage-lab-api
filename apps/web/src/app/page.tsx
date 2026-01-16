import { auth, signIn, signOut } from "@/auth"

export default async function Home() {
  const session = await auth()

  return (
    <main style={{ padding: '2rem' }}>
      <h1>StageLab</h1>
      
      {session ? (
        <div>
          <p>Signed in as {session.user?.email}</p>
          <form action={async () => {
            "use server"
            await signOut()
          }}>
            <button type="submit">Sign Out</button>
          </form>
        </div>
      ) : (
        <form action={async (formData) => {
          "use server"
          await signIn("credentials", formData)
        }} style={{ display: 'flex', flexDirection: 'column', gap: '0.5rem', maxWidth: '300px' }}>
          <input 
            name="email" 
            type="email" 
            placeholder="Email" 
            required
            style={{ padding: '0.5rem' }}
          />
          <input 
            name="password" 
            type="password" 
            placeholder="Password" 
            required
            style={{ padding: '0.5rem' }}
          />
          <button type="submit">Sign In</button>
        </form>
      )}
    </main>
  )
}
