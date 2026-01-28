import { auth, signOut } from '@/auth';

export default async function Home() {
  const session = await auth();

  return (
    <main style={{ padding: '0', margin: '0 auto' }}>
      <div>
        <p>Signed in as {session?.user?.email}</p>
        <form
          action={async () => {
            'use server';
            await signOut();
          }}
        >
          <button type="submit">Sign Out</button>
        </form>
      </div>
    </main>
  );
}
