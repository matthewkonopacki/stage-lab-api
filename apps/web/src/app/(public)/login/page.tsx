import LoginForm from '@/app/(public)/login/components/LoginForm';

export default async function Login({ searchParams }: { searchParams: Promise<{ error?: string }> }) {
  const { error } = await searchParams;
  return <LoginForm error={error} />;
}